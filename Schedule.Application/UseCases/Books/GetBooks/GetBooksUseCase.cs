using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;

namespace Schedule.Application.UseCases.Books.GetBooks
{
    public sealed class GetBooksUseCase : IGetBooksUseCase
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Result<List<Book>> Execute()
        {
            var result = new Result<List<Book>>();

            try
            {

                var books =  _bookRepository.GetAll();

                if(books == null)
                {
                    return result = new Result<List<Book>>
                    {
                        Message = "Nenhum Livro encontrado",
                        Sucess = false
                    };
                }

                return result = new Result<List<Book>>
                {
                    Message = "Sucesso",
                    Sucess = true,
                    Data = books.Result
                };
               // var book = _bookRepository.GetAll();

                //return book;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
