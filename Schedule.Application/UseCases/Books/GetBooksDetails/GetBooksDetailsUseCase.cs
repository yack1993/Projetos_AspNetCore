using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;

namespace Schedule.Application.UseCases.Books.GetBooksDetails
{
    public class GetBooksDetailsUseCase : IGetBooksDetailsUseCase
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksDetailsUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Result<Book>> Execute(string id)
        {
            var result = new Result<Book>();

            try
            {
                Book book = await _bookRepository.Get(id);

                if(book == null)
                {
                    return result = new Result<Book>
                    {
                        Message = "Livro não encontrado",
                        Sucess = false
                    };
                }

                return result = new Result<Book>
                {
                    Message = "Sucesso",
                    Sucess = true,
                    Data = book
                };
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
