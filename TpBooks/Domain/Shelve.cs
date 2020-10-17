using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpBooks.Domain
{
    public class Shelve
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public List<Bookdto> Books { get; set; }

        public Shelve(Guid id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}