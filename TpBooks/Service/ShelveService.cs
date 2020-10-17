using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TpBooks.Data;
using TpBooks.Domain;

namespace TpBooks.Service
{
    public class ShelveService
    {
        private readonly DataContext _context;

        public void AddEntity(Shelvesdto entity)
        {
            _context.Shelves.Add(entity);
            _context.SaveChanges();
        }

        public async Task<List<Shelvesdto>> GetAll()
        {
            return await _context.Shelves.ToListAsync();
        }

        public async Task<Shelvesdto> GetByBookId(Guid id)
        {
            var book = _context.Book.SingleOrDefault(d => d.Id == id);
            var shelve = await _context.Shelves.Where(s => s.Books.Contains(book)).SingleOrDefaultAsync();

            return shelve;
        }

        public async Task<Shelvesdto> GetById(Guid id)
        {
            return await _context.Shelves.Where(s => s.Id == id).SingleOrDefaultAsync();
        }

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