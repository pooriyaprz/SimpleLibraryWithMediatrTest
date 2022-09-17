using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Mappings
{
    public static class ModelBuilderMappingConfiguration
    {
        public static void AddMappings(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BooksMapping());
            builder.ApplyConfiguration(new BorrowedBooksMappings());

        }
    }
}
