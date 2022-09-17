using Domain.Common;
using Domain.Common.Enums;

namespace Domain.Entities
{
    public class BorrowedBooks : BaseAuditableEntity
    {
        public Guid BookId { get; set; }
        public  Book Book { get; set; }
        public Guid UserId { get; set; }
        public  ApplicationUser User { get; set; }
        public BorrowdBooksEnum Status { get; set; }
    }
}
