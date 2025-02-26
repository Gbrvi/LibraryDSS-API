using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDSS.Exception
{
    public class ErrorOnValidationException : LibraryDSSException
    {
        private readonly List<string> _errors;

        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages;
        }

        public override List<string> GetErrorMessages() => _errors;
      

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
       
    }
}
