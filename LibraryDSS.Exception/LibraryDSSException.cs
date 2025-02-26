using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDSS.Exception 
{
    public abstract class LibraryDSSException : SystemException
    {
        protected LibraryDSSException(string message) : base(message)
        {
            
        }
        public abstract List<string> GetErrorMessages();
        public abstract HttpStatusCode GetStatusCode();
    }
}
