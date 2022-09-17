using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Mappings
{
    public class BooksMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.Name)
               .HasMaxLength(255)
               .IsRequired();
            builder.Property(x => x.AuthorName)
              .HasMaxLength(255)
              .IsRequired();
            builder.Property(x => x.ReleaseDate);
            builder.Property(x => x.Count);

            builder.HasMany(x => x.BorrowedBooks)
               .WithOne(x => x.Book)
               .HasForeignKey(x => x.BookId)
               .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
