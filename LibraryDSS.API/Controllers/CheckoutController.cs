using LibraryDSS.API.UseCases.Checkouts;
using LibraryDSS.API.Services.LoggedUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDSS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CheckoutController : ControllerBase
    {
        [HttpPost]
        [Route("{bookId}")]
        public IActionResult BookCheckout(Guid bookId)
        {
            var loggedUser = new loggedUserService(HttpContext);

            var useCase = new RegisterBookCheckoutUseCase(loggedUser);

            useCase.Execute(bookId);
            return NoContent();
        }
    }
}
