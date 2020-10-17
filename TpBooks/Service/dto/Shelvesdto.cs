using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpBooks.Domain;

namespace TpBooks
{
    public class Shelvesdto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public List<Bookdto> Books { get; set; }

        public Shelvesdto(Guid id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}