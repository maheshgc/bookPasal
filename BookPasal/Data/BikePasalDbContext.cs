using BookPasal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BookPasal.Data
{
    public class BikePasalDbContext: DbContext
    {

        public BikePasalDbContext(DbContextOptions<BikePasalDbContext> options): base(options)
        {

        }

        public DbSet<Bike> Bikes { get; set; }

        public DbSet<BookPasal.Models.Book> Book { get; set; }


    }
}