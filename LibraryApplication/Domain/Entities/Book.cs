using Domain.Common;

namespace Domain.Entities
{
    public class Book : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Count { get; set; }
        public ICollection<BorrowedBooks> BorrowedBooks { get; set; }

    }
}
