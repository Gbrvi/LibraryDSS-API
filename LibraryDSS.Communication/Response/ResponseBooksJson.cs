using LibraryDSS.Communication.Request;
namespace LibraryDSS.Communication.Response
{
    public class ResponseBooksJson()
    {
        public ResponsePaginationJson Pagination { get; set; } = default!;
        public List<ResponseBookJson> Books { get; set; } = [];
    }
}
