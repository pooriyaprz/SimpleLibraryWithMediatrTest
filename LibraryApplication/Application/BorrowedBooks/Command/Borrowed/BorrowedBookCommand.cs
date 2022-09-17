using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Common.Enums;
using Domain.Entities;
using Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BorrowedBooks.Command.Borrowed
{
    public record BorrowedBookCommand : IRequest<string>
    {
        public Guid BookId { get; init; }
        public string UserId { get; init; }
    }
    public class BorrowedBookCommandHandler : IRequestHandler<BorrowedBookCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        public BorrowedBookCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(BorrowedBookCommand request, CancellationToken cancellationToken)
        {
            Book? book = await _dbContext.Books.Include(x => x.BorrowedBooks).FirstOrDefaultAsync(x => x.Id == request.BookId);
            if (book == null)
            {
                throw new Exception();
            }
            bool bookCanBorrow = book.BorrowedBooks?.Where(x => x.Status == BorrowdBooksEnum.Borrowed).Count() < book.Count ? true : false;
            if (!bookCanBorrow)
            {
                throw new OverLimitException("This book is not availble now!");
            }

            Domain.Entities.BorrowedBooks? bBooks = new Domain.Entities.BorrowedBooks()
            {

                BookId = book.Id,
                UserId = new Guid(request.UserId),
                Status = BorrowdBooksEnum.Borrowed
            };

            book.AddDomainEvent(new BorrowedBookCreatedEvent(bBooks));

            _dbContext.BorrowedBooks.Add(bBooks);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return bBooks.Id.ToString();
        }

    }
}
