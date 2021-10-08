using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

    }
}
