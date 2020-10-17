using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TpBooks.Data;
using TpBooks.Service;
using static TpBooks.Service.BookService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TpBooks.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShelvesController : ControllerBase
    {
        private readonly ShelveService _shelveService = new ShelveService();
        private readonly BookService _bookService = new BookService();

        // GET:
        [HttpGet]
        public ActionResult<Shelvesdto> Get()
        {
            return Ok(_shelveService.Getshelvess());
        }

        // GET /id
        [HttpGet("{id}")]
        public ActionResult<Shelvesdto> GetShelves(string id)
        {
            SQLiteDataReader ID = null;

            Guid idguid = Guid.Parse(id);
            var shelve = _shelveService.Getshelvess(idguid);

            if (shelve is null)
            {
                var a = GetBooks(idguid);
                shelve = new Shelvesdto(a.Id, a.Title);
            }

            return shelve;
        }

        // POST
        [HttpPost("{id}")]
        public ActionResult<Shelvesdto> Post(string id)
        {
            var db = new DataContext();

            Guid idguid = Guid.Parse(id);

            Bookdto book = GetBooks(idguid);

            if (!book.Equals(null))
            {
                List<Shelvesdto> shelves = null;
                Shelvesdto shelve = new Shelvesdto(book.Id, book.Title);
                shelves.Add(shelve);

                // Create
                Console.WriteLine("Inserting a new book");
                db.Add(shelve);
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var Book = db.Book
                    .OrderBy(b => b.Id)
                    .First();

                return Ok(shelve);
            }

            return NotFound();
        }
    }
}