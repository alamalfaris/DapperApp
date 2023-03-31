using Dapper;
using DapperApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration _config;

        public BookRepository(IConfiguration config)
        {
            _config = config;
        }

        private SqlConnection GetConnection()
        {
            var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return connection;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            //using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var connection = GetConnection();
            var books = await connection.QueryAsync<Book>("select * from Books");
            return books.ToList();
        }

        public async Task<Book> GetBook(int bookId)
        {
            var connection = GetConnection();
            var book = await connection.QueryFirstAsync<Book>("select * from Books where Id = @Id",
                new { Id = bookId });

            return book;
        }

        public async Task<List<Book>> CreateBook(Book book)
        {
            var connection = GetConnection();
            await connection.ExecuteAsync("insert into Books (Title, Author, PublishedYear, IsDeleted, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime) values (@Title, @Author, @PublishedYear, @IsDeleted, @CreatedBy, @CreatedTime, @UpdatedBy, @UpdatedTime)", book);

            return await GetAllBooks();
        }

        public async Task<List<Book>> UpdateBook(Book book)
        {
            var connection = GetConnection();
            await connection.ExecuteAsync("update Books set Title = @Title, Author = @Author, PublishedYear = @PublishedYear, UpdatedBy = @UpdatedBy, UpdatedTime = @UpdatedTime where Id = @Id", book);
            
            return await GetAllBooks();
        }

        public async Task<List<Book>> DeleteBook(int bookId)
        {
            var connection = GetConnection();
            await connection.ExecuteAsync("delete from books where Id = @Id", new {Id = bookId });

            return await GetAllBooks();
        }
    }
}
