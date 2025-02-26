using System.Net;


namespace LibraryDSS.Exception
{
    public class InvalidLoginException : LibraryDSSException
    {
        public InvalidLoginException() : base("Email e/ou senha invalidos.")
        {
            
        }
        public override List<string> GetErrorMessages() => [Message];
      

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
       
    }
}
