using FluentValidation;

namespace Application.BorrowedBooks.Command.Borrowed
{

    public class BorrowedBookCommandValidator : AbstractValidator<BorrowedBookCommand>
    {
        public BorrowedBookCommandValidator()
        {
            RuleFor(v => v.BookId)

                .NotEmpty();
            RuleFor(v => v.UserId)

                 .NotEmpty();

        }
    }
}
