using Application.Books.Queries.GetBooksWithPagination;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries.GetBook
{
    public record GetBookQueryCommand(Guid Id) : IRequest<BookDto>;
    public class GetBookQueryHandler : IRequestHandler<GetBookQueryCommand, BookDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetBookQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(GetBookQueryCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == request.Id);
            return _mapper.Map<BookDto>(book);

        }
    }
}
