using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpBooks.Domain
{
    public class ShelveRepo
    {
        public static List<Shelve> GetShelves()
        {
            List<Shelve> shelves = new List<Shelve>();

            shelves.Add(new Shelve(
                Guid.Parse("a4df38dd-58aa-4fd4-bff9-afd149905b7a"),
                "a"));

            return shelves;
        }
    }
}