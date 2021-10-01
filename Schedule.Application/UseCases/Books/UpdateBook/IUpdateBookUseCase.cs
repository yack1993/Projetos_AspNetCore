using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;

namespace Schedule.Application.UseCases.Books.UpdateBook
{
    public interface IUpdateBookUseCase
    {
        Task<Result> Execute(string id, Book bookIn);
    }
}
