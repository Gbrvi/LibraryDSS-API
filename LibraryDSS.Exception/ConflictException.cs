using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace LibraryDSS.Exception
{
    public class ConflictException : LibraryDSSException
    {
        public ConflictException(string message) : base(message)
        {
        }
        public override List<string> GetErrorMessages() => [Message];


        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Conflict;
    }
}
