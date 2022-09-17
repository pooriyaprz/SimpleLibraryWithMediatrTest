using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class BooksCreatedEvents : BaseEvent
    {
        public BooksCreatedEvents(Entities.Book book)
        {
            Book = book;
        }
        public Entities.Book Book { get; }
    }
}
