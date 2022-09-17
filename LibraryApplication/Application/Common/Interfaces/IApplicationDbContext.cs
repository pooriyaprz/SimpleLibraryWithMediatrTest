using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Book> Books { get; }
        public  DbSet<ApplicationUser> AspNetUsers { get; }
        public  DbSet<ApplicationRole> AspNetRoles { get; }

        public  DbSet<Domain.Entities.BorrowedBooks> BorrowedBooks { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
