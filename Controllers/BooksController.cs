using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books
                .Include(b => b.Genre)
                .ToList();

            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _context.Books
                .Include(b => b.Genre)
                .SingleOrDefault(b => b.Id == id);

            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if(book == null)
            {
                return NotFound();
            }

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _context.Genre.ToList()
            };

            return View("BookForm", viewModel);
        }

        public IActionResult New()
        {
            var viewModel = new BookFormViewModel
            {
                Genres = _context.Genre.ToList()
            };

            return View("BookForm", viewModel);
        }

        // Books/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Save(Book book)
        {
            if (book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                _context.Books.Add(book);
            }
            else
            {
                var bookIndDb = _context.Books.Single(b => b.Id == book.Id);
                bookIndDb.Name = book.Name;
                bookIndDb.AuthorName = book.AuthorName;
                bookIndDb.GenreId = book.GenreId;
                bookIndDb.ReleaseDate= book.ReleaseDate;
                bookIndDb.DateAdded= book.DateAdded;
                bookIndDb.NumberInStock= book.NumberInStock;

            }
            try
            {
                _context.SaveChanges();

            }
            catch(DbUpdateException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Books");
        }

        // POST: Books/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Books.FindAsync(id);
            _context.Books.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [Route("books/released/{year:regex(^\\d{{4}}$)}/{month:range(1, 12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}