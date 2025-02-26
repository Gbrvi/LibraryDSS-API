using LibraryDSS.API.Infraestructure.DataAccess;
using LibraryDSS.API.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace LibraryDSS.API.Services.LoggedUser
{
    public class loggedUserService
    {
        private readonly HttpContext _context;
        public loggedUserService(HttpContext httpContext)
        {
            _context = httpContext;
        }

        public User GetUser( LibraryDSSDbContext dbContext)
        {
            var authentication = _context.Request.Headers.Authorization.ToString();
            var token = authentication["Bearer".Length..].Trim();

            // JwtSecurty has the claims 
            var tokenHandler = new JwtSecurityTokenHandler();
            // Read the tokean
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
            // Get the sub (Id) value as string
            var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;
            // Convert to Guid Id 
            var userId = Guid.Parse(identifier);

            return dbContext.Users.First(user => user.Id == userId);
        }
       
    }
}
