using System;
using System.Collections.Generic;
using System.Text;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Schedule.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly string connectionStringMongo;
        private readonly string booksCollectionName;
        private readonly string databaseName;

        private readonly IMongoCollection<Book> _books;

        public BookRepository(string connectionStringMongo, string databaseName, string booksCollectionName)
        {
            this.connectionStringMongo = connectionStringMongo;
            this.booksCollectionName = booksCollectionName;
            this.databaseName = databaseName;

            var client = new MongoClient(connectionStringMongo);
            var database = client.GetDatabase(databaseName);

            _books = database.GetCollection<Book>(booksCollectionName);
        }


        public Task<Book> Get(string id)
        {
            try
            {
                var resul = _books.Find<Book>(book => book.Id == id).FirstOrDefaultAsync();

                return resul;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public Task<List<Book>> GetAll()
        {
            try
            {
                var result = _books.Find<Book>(book => true).ToListAsync();

                return result;             
            }
            catch(Exception ex)
            {
                throw new Exception("Erro conexão");
            }
        }

        public Book AddBook(Book book)
        {
            try
            {
                _books.InsertOneAsync(book);
                return book;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void UpdateBook(string id, Book bookIn)
        {
            try
            {
                _books.ReplaceOneAsync(book => book.Id == id, bookIn);

                return;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void DeleteBook(string id)
        {
            try
            {
                _books.DeleteOneAsync(book => book.Id == id);

                return;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
