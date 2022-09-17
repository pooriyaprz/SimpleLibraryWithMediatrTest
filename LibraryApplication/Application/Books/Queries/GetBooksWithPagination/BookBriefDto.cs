
using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries.GetBooksWithPagination
{
    public class BookBriefDto:IMapFrom<Book>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Count { get; set; }

    }
}
