using RoyalLibrary.Domain.Commands;
using RoyalLibrary.Domain.Commands.Books;
using RoyalLibrary.Domain.Entities.Book;
using RoyalLibrary.Domain.Repositories.Interface.Books;
using RoyalLibrary.Domain.Validation.Books;

namespace RoyalLibrary.Domain.Handlers
{
    public class BookHandler
    {
        private readonly IBookRepository _repository;

        public BookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateBookCommand cmd)
        {
            Book book = new Book(cmd.Title,
                                  cmd.FirstName,
                                  cmd.LastName,
                                  cmd.TotalCopies,
                                  cmd.CopiesInUse,
                                  cmd.Type,
                                  cmd.Isbn,
                                  cmd.Category);

            var validator = new BookValidation();
            var validationResult = validator.Validate(book);

            if (!validationResult.IsValid)
                return new CommandResult(false, "Error when adding Book.", validationResult.Errors);

            book.Id = _repository.Add(book);

            return new CommandResult(true, "Book inserted successfully", book);
        }
    }
}
