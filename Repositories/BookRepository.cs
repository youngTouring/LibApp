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
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.Include(b => b.Genre);
        }

        public Book GetBookById(int id) => _context.Books.Find(id);
        public void AddBook(Book book) => _context.Books.Add(book);
        public void DeleteBook(int id) => _context.Books.Remove(GetBookById(id));
        public void UpdateBook(Book book) => _context.Books.Update(book);
        public void Save() => _context.SaveChanges();
    }
}
