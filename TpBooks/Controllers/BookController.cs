using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TpBooks.Service;

namespace TpBooks.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        [Route("[controller]/{title}/{author}")]
        public ActionResult<Bookdto> Get(string title, string author)
        {
            BookService.LoadJson(BookService.ReadApiGoogle(title, author));
            return Ok();
        }
    }
}