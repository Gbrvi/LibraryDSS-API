using LibraryDSS.API.UseCases.Login.DoLogin;
using LibraryDSS.Communication.Request;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDSS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult DoLogin(RequestLoginJson request)
        {
            var useCase = new DoLoginUseCase();

            var response = useCase.Execute(request);
        
            return Ok(response);
        }

    }
}
