using FluentValidation.Results;
using LibraryDSS.API.Domain.Entities;
using LibraryDSS.API.Infraestructure.DataAccess;
using LibraryDSS.API.Infraestructure.Security.Cryptography;
using LibraryDSS.API.Infraestructure.Security.Token.Access;
using LibraryDSS.Communication.Request;
using LibraryDSS.Communication.Response;
using LibraryDSS.Exception;
using Microsoft.EntityFrameworkCore;

namespace LibraryDSS.API.UseCases.Users.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {
            var dbContext = new LibraryDSSDbContext();

            Validate(request, dbContext);

            var cryptography = new BCryptAlgorithm();


            var entity = new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = cryptography.HashPassword(request.Password),
            };

            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            var tokenGenerator = new JwtTokenGenerator();

            return new ResponseRegisteredUserJson
            {
                Name = entity.Name,
                AccessToken = tokenGenerator.Generate(entity)
            };
        }

        private void Validate(RequestUserJson request, LibraryDSSDbContext dbContext) // Funcao exclusiva para validar
        {

            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            var existUserWithEmail = dbContext.Users.Any(user => user.Email.Equals(request.Email));

            if (existUserWithEmail)
                result.Errors.Add(new ValidationFailure("Email", "Email ja registrado na plataforma"));

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList(); // armazena todos erros 

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
