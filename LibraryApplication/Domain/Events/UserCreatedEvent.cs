using Domain.Common;
using Domain.Entities;

namespace Domain.Events
{
    public class UserCreatedEvent : BaseEvent
    {
        public UserCreatedEvent(ApplicationUser user)
        {
            User = user;
        }
        public ApplicationUser User { get; }
    }
}
