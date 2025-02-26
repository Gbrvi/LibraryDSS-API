using LibraryDSS.API.UseCases.Login.DoLogin;
using LibraryDSS.Communication.Request;
using LibraryDSS.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDSS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status401Unauthorized)]
        public IActionResult DoLogin(RequestLoginJson request)
        {
            var useCase = new DoLoginUseCase();

            var response = useCase.Execute(request);
        
            return Ok(response);
        }

    }
}
