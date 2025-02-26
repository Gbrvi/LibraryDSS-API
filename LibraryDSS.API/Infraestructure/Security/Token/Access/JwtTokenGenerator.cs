using LibraryDSS.API.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace LibraryDSS.API.Infraestructure.Security.Token.Access
{
    // Generating JWT to access token
    public class JwtTokenGenerator
    {
 
        public string Generate(User user)
        {

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()) // Create a claim contains (Key -> Value). Using
                                                                           // Sub to hidden the UserID
            };

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                // How many times till disconnect
                Expires = DateTime.UtcNow.AddMinutes(60),
                Subject = new ClaimsIdentity(claims),
                //Credentials Key
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature) // Most famous Algorithm
            };

            var tokenHandler = new JwtSecurityTokenHandler();
         
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken); //Return a string

        }

        private static SymmetricSecurityKey SecurityKey()
        {
            // 32 caracters key 
            var signingKey = "xwI09V8fkIZTMOLxypF3OxiugAJICkkA";
            // Turn into byte array
            var symmetricKey = Encoding.UTF8.GetBytes(signingKey);

            return new SymmetricSecurityKey(symmetricKey); // Needs a byte array
        }

    }
}
