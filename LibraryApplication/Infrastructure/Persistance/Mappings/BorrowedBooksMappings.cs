using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Mappings
{
    public class BorrowedBooksMappings : IEntityTypeConfiguration<BorrowedBooks>
    {
        public void Configure(EntityTypeBuilder<BorrowedBooks> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.CreatedBy);
            builder.HasOne(x => x.Book)
               .WithMany(x => x.BorrowedBooks)
               .HasForeignKey(x => x.BookId)
               .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.User)
            .WithMany(x => x.BorrowedBooks)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
