using Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.EventHandlers
{
    public class BookEventHandler : INotificationHandler<BooksCreatedEvents>
    {
        public Task Handle(BooksCreatedEvents notification, CancellationToken cancellationToken)
        {


            return Task.CompletedTask;
        }
    }
}
