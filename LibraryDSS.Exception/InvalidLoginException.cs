using System.Net;


namespace LibraryDSS.Exception
{
    public class InvalidLoginException : LibraryDSSException
    {

        public override List<string> GetErrorMessages()
        {
            return ["Email e/ou senha invalidos."];
        }

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
       
    }
}
