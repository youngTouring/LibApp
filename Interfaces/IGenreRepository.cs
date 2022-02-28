using System.Collections.Generic;
using LibApp.Models;
namespace LibApp.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
        Genre GetGenreById(int genreId);
        //void AddBook(Book book);
        //void DeleteBook(int bookId);
        //void UpdateBook(Book book);
        void Save();
    }
}