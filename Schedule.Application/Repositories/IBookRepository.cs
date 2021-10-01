using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;

namespace Schedule.Application.Repositories
{
    public interface IBookRepository
    {
        Task<Book> Get(string id);
        Task<List<Book>> GetAll();
        Book AddBook(Book book);
        void UpdateBook(string id, Book bookIn);
        void DeleteBook(string id);
    }
}
