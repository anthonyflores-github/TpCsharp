using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using TpBooks.Domain;

namespace TpBooks.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Bookdto> Book { get; set; }

        public DbSet<Shelvesdto> Shelves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");
    }
}