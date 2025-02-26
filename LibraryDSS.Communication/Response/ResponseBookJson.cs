using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDSS.Communication.Response
{
    public class ResponseBookJson
    {
        public Guid Id { get; set; }
        public String Title { get; set; } = String.Empty;
        public String Author { get; set; } = String.Empty;
    }
}
