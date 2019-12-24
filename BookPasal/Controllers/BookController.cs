using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookPasal.Data;
using BookPasal.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookPasal.Controllers
{
    public class BookController : Controller
    {
        private BookPasalDbContext dbContext;
        public BookController(BookPasalDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Book> books = dbContext.Books.ToList();
            return View(books);
        }
    }
}
