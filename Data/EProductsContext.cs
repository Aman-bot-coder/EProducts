using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EProducts.Model;

namespace EProducts.Data
{
    public class EProductsContext : DbContext
    {
        public EProductsContext (DbContextOptions<EProductsContext> options)
            : base(options)
        {
        }

        public DbSet<EProducts.Model.Productss> Productss { get; set; } = default!;
        public DbSet<EProducts.Model.Category> Category { get; set; } = default!;
    }
}
