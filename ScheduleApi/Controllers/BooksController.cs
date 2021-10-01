using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;
using Schedule.Application.UseCases.Books.GetBooks;
using Schedule.Application.UseCases.Books.GetBooksDetails;
using Schedule.Application.UseCases.Books.AddBook;
using Schedule.Application.UseCases.Books.UpdateBook;
using Schedule.Application.UseCases.Books.DeleteBook;

namespace ScheduleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IGetBooksUseCase _getBooksUseCase;
        private readonly IGetBooksDetailsUseCase _getBooksDetailsUseCase;
        private readonly IAddBookUseCase _addBookUseCase;
        private readonly IUpdateBookUseCase _updateBookUseCase;
        private readonly IDeleteBookUseCase _deleteBookUseCase;

        public BooksController(IGetBooksUseCase getBooksUseCase, 
            IGetBooksDetailsUseCase getBooksDetailsUseCase,
            IAddBookUseCase addBookUseCase,
            IUpdateBookUseCase updateBookUseCase,
            IDeleteBookUseCase deleteBookUseCase)
        {
            _getBooksUseCase = getBooksUseCase;
            _getBooksDetailsUseCase = getBooksDetailsUseCase;
            _addBookUseCase = addBookUseCase;
            _updateBookUseCase = updateBookUseCase;
            _deleteBookUseCase = deleteBookUseCase;
        }

        [HttpGet("{id:length(24)}", Name = "Get")]
        public async Task<IActionResult> Get(string id)
        {
            Result<Book> output = await _getBooksDetailsUseCase.Execute(id);
            return Ok(output);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            Result<List<Book>> output = _getBooksUseCase.Execute();
            return Ok(output);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            Result output = await _addBookUseCase.Execute(book);
            return Ok(output);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Execute(string id, Book bookIn)
        {
            var book = _getBooksDetailsUseCase.Execute(id);
            if (book == null)
            {
                return NotFound();
            }
            _updateBookUseCase.Execute(id, bookIn);
            //return Ok(ouput);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Execute(string id)
        {
            var book = _getBooksDetailsUseCase.Execute(id);

            if(book == null)
            {
                return NotFound();
            }



             _deleteBookUseCase.Execute(id);
            return NoContent();

        }

    }
}
