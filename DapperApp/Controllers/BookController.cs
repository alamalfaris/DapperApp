using DapperApp.Models;
using DapperApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();

            return Ok(books);
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBook(int bookId)
        {
            var book = await _bookRepository.GetBook(bookId);

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            var books = await _bookRepository.CreateBook(book);

            return Ok(books);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] Book book)
        {
            var books = await _bookRepository.UpdateBook(book);

            return Ok(books);
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var books = await _bookRepository.DeleteBook(bookId);

            return Ok(books);
        }
    }
}
