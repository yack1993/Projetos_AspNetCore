using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;

namespace Schedule.Application.UseCases.Books.DeleteBook
{
    public sealed class DeleteBookUseCase : IDeleteBookUseCase
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Result> Execute(string id)
        {
            try
            {
                _bookRepository.DeleteBook(id);

                var result = new Result
                {
                    Message = "Sucesso",
                    Sucess = true
                };

                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
