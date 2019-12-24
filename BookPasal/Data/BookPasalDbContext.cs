using BookPasal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookPasal.Data
{
    public class BookPasalDbContext: DbContext
    {
        public BookPasalDbContext(DbContextOptions<BookPasalDbContext> options)
           : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<ModelName> tableName { get; set; }

    }
}
