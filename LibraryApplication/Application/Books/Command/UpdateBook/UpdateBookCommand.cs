using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Command.UpdateBook
{
    public record UpdateBookCommand : IRequest
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string AuthorName { get; init; }

        public DateTime ReleaseDate { get; init; }
        public int Count { get; init; }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {

        private readonly IApplicationDbContext _dbContext;

        public UpdateBookCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Books
                       .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            entity.Name = request.Name;
            entity.AuthorName = request.AuthorName;
            entity.ReleaseDate = request.ReleaseDate;
            entity.Count = request.Count;


            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
