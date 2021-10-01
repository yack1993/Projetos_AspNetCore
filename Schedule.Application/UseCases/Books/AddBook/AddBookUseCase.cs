using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;


namespace Schedule.Application.UseCases.Books.AddBook
{
    public sealed class AddBookUseCase : IAddBookUseCase
    {
        private readonly IBookRepository _bookRepository;

        public AddBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Result> Execute(Book book)
        {
            var message = string.Empty;
            var result = new Result();

            try
            {
                if(book.BookName == null || book.Category == null || book.Author == null || book.Price == 0)
                {
                    if (book.BookName == null)
                        message = "Informe o nome do livo";
                    else if (book.Category == null)
                        message = "Informe a categoria do livro";
                    else if (book.Author == null)
                        message = "Informe o Author";
                    else if (book.Price == 0)
                    {
                        message = "Informe o Preço";
                    }

                    return result = new Result
                    {
                        Message = "Erro",
                        Sucess = false
                    };
                }

                 var _id = _bookRepository.AddBook(book);

                result = new Result
                {
                    Message = _id == null ? "Erro ao cadastrar" : "Cadastro realizado com Sucesso",
                    Sucess = _id == null ? false : true
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
