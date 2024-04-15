using FluentValidation;
using RoyalLibrary.Domain.Entities.Book;

namespace RoyalLibrary.Domain.Validation.Books
{
    public class BookValidation : AbstractValidator<Book>
    {
        public BookValidation()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Title is mandatory");
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("FirstName is mandatory");
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("LastName is mandatory");
            RuleFor(x => x.TotalCopies).NotNull().NotEmpty().WithMessage("TotalCopies is mandatory");
            RuleFor(x => x.CopiesInUse).NotNull().NotEmpty().WithMessage("CopiesInUse is mandatory");
        }     
    }    
}
