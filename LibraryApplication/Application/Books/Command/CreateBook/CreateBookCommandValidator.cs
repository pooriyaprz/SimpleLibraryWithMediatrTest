using FluentValidation;

namespace Application.Books.Command.CreateBook
{

    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();
            RuleFor(v => v.AuthorName)
                .MaximumLength(200)
                
                 .NotEmpty();

            RuleFor(v => v.Count)
                .NotNull();
           
               
        }
    }

}
