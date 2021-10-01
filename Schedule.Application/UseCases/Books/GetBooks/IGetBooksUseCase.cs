using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;

namespace Schedule.Application.UseCases.Books.GetBooks
{
    public interface IGetBooksUseCase
    {
        Result<List<Book>> Execute();
    }
}
