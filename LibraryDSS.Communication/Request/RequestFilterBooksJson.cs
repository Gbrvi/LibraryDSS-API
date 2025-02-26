using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDSS.Communication.Request
{
    public class RequestFilterBooksJson
    {
        public int PageNumber { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
