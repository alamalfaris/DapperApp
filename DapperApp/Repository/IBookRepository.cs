using DapperApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperApp.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBook(int bookId);
        Task<List<Book>> CreateBook(Book book);
        Task<List<Book>> UpdateBook(Book book);
        Task<List<Book>> DeleteBook(int bookId);
    }
}
