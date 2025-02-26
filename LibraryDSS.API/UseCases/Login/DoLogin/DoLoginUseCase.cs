using LibraryDSS.API.Infraestructure.DataAccess;
using LibraryDSS.API.Infraestructure.Security.Cryptography;
using LibraryDSS.API.Infraestructure.Security.Token.Access;
using LibraryDSS.Communication.Request;
using LibraryDSS.Communication.Response;
using LibraryDSS.Exception;

namespace LibraryDSS.API.UseCases.Login.DoLogin
{
    public class DoLoginUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestLoginJson request)
        {
            var dbContext = new LibraryDSSDbContext();

            var user = dbContext.Users.FirstOrDefault(user => user.Email.Equals(request.Email)); // Verify if email is stored on DB

            // If not find user
            if (user is null)
            {
                throw new InvalidLoginException();
            } 

            // Use cryptography to verify if the password is correct
            var cryptography = new BCryptAlgorithm();
            var passwordIsValid = cryptography.Verify(request.Password, user);

            if(passwordIsValid == false)
            {
                throw new InvalidLoginException(); 
            }

            // Make a new token
            var tokenGenerator = new JwtTokenGenerator();

            // Return ResponseRegister
            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                AccessToken = tokenGenerator.Generate(user)
            };

        }
    }
}
