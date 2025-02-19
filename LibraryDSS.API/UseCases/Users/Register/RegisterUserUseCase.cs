using LibraryDSS.API.Domain.Entities;
using LibraryDSS.API.Infraestructure;
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
            Validate(request);

            var entity = new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
            };

            var dbContext = new LibraryDSSDbContext();

            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            return new ResponseRegisteredUserJson
            {
                Name = entity.Name,
            };
        }

        private void Validate(RequestUserJson request) // Funcao exclusiva para validar
        {

            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList(); // armazena todos erros 

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
