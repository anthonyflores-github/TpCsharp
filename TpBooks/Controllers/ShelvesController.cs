using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TpBooks.Data;
using TpBooks.Service;

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
            Guid idguid = Guid.Parse(id);
            var shelve = _shelveService.Getshelvess(idguid);

            if (shelve is null)
            {
                return NotFound();
            }

            return Ok(_shelveService.Getshelvess(idguid));
        }

        // POST api/<ValuesController>
        [HttpPost("{id}")]
        public ActionResult<Shelvesdto> Post(string id)
        {
            Guid idguid = Guid.Parse(id);
            Bookdto book = _bookService.GetPizzas(idguid);

            if (!book.Equals(null))
            {
                List<Shelvesdto> shelves = null;
                Shelvesdto shelve = new Shelvesdto(book.Id, book.Title);
                shelves.Add(shelve);

                using (var db = new DataContext())
                {
                    // Create
                    Console.WriteLine("Inserting a new book");
                    db.Add(shelve);
                    db.SaveChanges();

                    // Read
                    Console.WriteLine("Querying for a blog");
                    var Book = db.Book
                        .OrderBy(b => b.Id)
                        .First();
                }

                return Ok(shelve);
            }

            return NotFound();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}