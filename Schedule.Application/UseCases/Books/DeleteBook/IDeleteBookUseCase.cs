using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;

namespace Schedule.Application.UseCases.Books.DeleteBook
{
    public interface IDeleteBookUseCase
    {
        Task<Result> Execute(string id);
    }
}
