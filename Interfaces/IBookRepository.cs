using LibApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int bookId);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int bookId);
    }
}
