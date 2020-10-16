using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpBooks.Domain;

namespace TpBooks.Service
{
    public class ShelveService
    {
        public List<Shelvesdto> Getshelvess()
        {
            return ShelveRepo.GetShelves()
                .Select(p => new Shelvesdto(
                    p.Id,
                    p.Title
                    ))
                .ToList();
        }

        public Shelvesdto Getshelvess(Guid id)
        {
            return ShelveRepo.GetShelves()
                .Where(p => p.Id == id)
                .Select(p => new Shelvesdto(p.Id, p.Title))
                .FirstOrDefault();
        }
    }
}