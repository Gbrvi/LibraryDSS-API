using LibraryDSS.Communication.Request;
using LibraryDSS.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryDSS.API.UseCases.Users.Register;
using LibraryDSS.Exception;


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
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Create(RequestUserJson request)
        {
            try
            {

                var response = _useCase.Execute(request);

                return Created(string.Empty, response);
            }

            catch(LibraryDSSException ex) // Exception da API
            {
                return BadRequest(new ResponseErrorMessagesJson
                { //Pode confiar na mensagem erro
                    Errors = ex.GetErrorMessages() 
                });
            }

            catch //Exception do Sistema
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson
                {
                    Errors = ["Erro Desconhecido "]
                });
            }

        }
    }
}
