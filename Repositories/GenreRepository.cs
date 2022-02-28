using LibApp.Data;
using LibApp.Models;
using LibApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genre;
        }

        public Genre GetGenreById(int id) => _context.Genre.Find(id);
        //public void AddBook(Book book) => _context.Books.Add(book);
        //public void DeleteBook(int id) => _context.Books.Remove(GetBookById(id));
        //public void UpdateBook(Book book) => _context.Books.Update(book);
        public void Save() => _context.SaveChanges();
    }
}
