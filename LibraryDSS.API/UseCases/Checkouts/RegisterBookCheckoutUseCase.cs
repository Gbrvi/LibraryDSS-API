using LibraryDSS.API.Infraestructure.DataAccess;
using LibraryDSS.API.Domain.Entities;
using LibraryDSS.Exception;
using LibraryDSS.API.Services.LoggedUser;

namespace LibraryDSS.API.UseCases.Checkouts
{
    public class RegisterBookCheckoutUseCase
    {
        private const int MAX_LOAN_DAYS = 7;

        private readonly loggedUserService _loggedUser;

        public RegisterBookCheckoutUseCase(loggedUserService loggedUser)
        {
            _loggedUser = loggedUser;
        }
        public void Execute(Guid bookId)
        {
            var dbContext = new LibraryDSSDbContext();

            Validate(dbContext, bookId);

            var user = _loggedUser.GetUser(dbContext);

            var entity = new Checkout
            {
                UserId = user.Id,
                BookId = bookId,
                ExpectedReturnDate = DateTime.UtcNow.AddDays(MAX_LOAN_DAYS),
            };

            dbContext.Checkouts.Add(entity);

            dbContext.SaveChanges();
        }


        private void Validate(LibraryDSSDbContext dbContext, Guid bookId)
        {
            var book = dbContext.Books.FirstOrDefault(book => book.Id == bookId);

            if (book is null)
            {
                throw new NotFoundException("Livro não encontrado");
            }
            // Check if the book is not returned
            var amountBookNotReturned = dbContext
                .Checkouts
                .Count(checkout => checkout.BookId == bookId && checkout.ReturnedDate == null);

            // Book

            if (amountBookNotReturned == book.Amount)
            {
                throw new ConflictException("Livro não está disponível para empréstimo.");
            }
        }
    }
}
