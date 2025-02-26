using LibraryDSS.Communication.Request;
using Microsoft.AspNetCore.Http;
using LibraryDSS.API.UseCases.Books;
using Microsoft.AspNetCore.Mvc;
using LibraryDSS.API.UseCases.Books.Filter;
using LibraryDSS.Communication.Response;

namespace LibraryDSS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("Filter")]
        [ProducesResponseType(typeof(ResponseBooksJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Filter(int pageNumber, string? title)
        {
            var useCase = new FilterBookUseCase();

            var result = useCase.Execute(new RequestFilterBooksJson
            {
                PageNumber = pageNumber,
                Title = title,
            });


            if(result.Books.Count > 0)
            {
                return Ok(result);
            }

            return NoContent();

        }
    }
}
