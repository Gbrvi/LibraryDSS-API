using LibraryDSS.Communication.Request;
using LibraryDSS.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryDSS.API.UseCases.Users.Register;


namespace LibraryDSS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RegisterUserUseCase _useCase;

        public UsersController(RegisterUserUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Create(RequestUserJson request)
        {

            var response = _useCase.Execute(request);

            return Created(string.Empty,response);
        }
    }
}
