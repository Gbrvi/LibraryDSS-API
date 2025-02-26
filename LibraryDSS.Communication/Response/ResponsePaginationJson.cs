using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDSS.Communication.Response
{
    public class ResponsePaginationJson
    {
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
    }
}
