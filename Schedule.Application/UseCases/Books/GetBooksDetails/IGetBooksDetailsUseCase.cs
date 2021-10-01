using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;

namespace Schedule.Application.UseCases.Books.GetBooksDetails
{
    public interface IGetBooksDetailsUseCase
    {
        Task<Result<Book>> Execute(string id);
    }
}
