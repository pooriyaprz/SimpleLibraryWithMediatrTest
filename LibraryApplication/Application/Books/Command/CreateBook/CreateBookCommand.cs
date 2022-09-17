using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Command.CreateBook
{
    public record CreateBookCommand : IRequest<Book>
    {
        public string Name { get; init; }
        public string AuthorName { get; init; }

        public DateTime ReleaseDate { get; init; }
        public int Count { get; init; }

    }
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateBookCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Book
            {
                AuthorName = request.AuthorName,
                Count = request.Count,
                ReleaseDate = request.ReleaseDate,
                Name = request.Name,
                CreatedAt = DateTime.UtcNow,

            };


            entity.AddDomainEvent(new BooksCreatedEvents(entity));

            _dbContext.Books.Add(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

    }
}
