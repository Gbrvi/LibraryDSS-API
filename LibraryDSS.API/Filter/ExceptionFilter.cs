using LibraryDSS.Communication.Response;
using LibraryDSS.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace LibraryDSS.API.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        // Filter to manage exceptions
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is LibraryDSSException libraryDSSException)
            {
                context.HttpContext.Response.StatusCode = (int) libraryDSSException.GetStatusCode();
                context.Result = new ObjectResult(new ResponseErrorMessagesJson
                {
                    Errors = libraryDSSException.GetErrorMessages()
                });
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new ObjectResult(new ResponseErrorMessagesJson
                {
                    Errors = ["Erro Desconhecido"]
                });
            }
        }
    }
}
