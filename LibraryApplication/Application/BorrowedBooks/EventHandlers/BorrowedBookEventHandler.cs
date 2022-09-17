using Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BorrowedBooks.EventHandlers
{
    public class BorrowedBookEventHandler : INotificationHandler<BorrowedBookCreatedEvent>
    {
        public Task Handle(BorrowedBookCreatedEvent notification, CancellationToken cancellationToken)
        {


            return Task.CompletedTask;
        }
    }
}
