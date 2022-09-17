using Application.Common.Interfaces;
using Domain.Common.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BorrowedBooks.Command.Returned
{
    public record ReturnedBookCommand : IRequest<string>
    {
        public Guid BookId { get; init; }
        public string UserId { get; init; }
    }
    public class ReturnedBookCommanddHandler : IRequestHandler<ReturnedBookCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;

        public ReturnedBookCommanddHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<string> Handle(ReturnedBookCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.BorrowedBooks? book = await _dbContext.BorrowedBooks.FirstOrDefaultAsync(x => x.BookId == request.BookId && x.UserId == new Guid(request.UserId));
            if (book == null)
            {
                throw new Exception();
            }


            book.Status = BorrowdBooksEnum.Returned;

            _dbContext.BorrowedBooks.Update(book);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return book.Id.ToString();
        }

    }
}
