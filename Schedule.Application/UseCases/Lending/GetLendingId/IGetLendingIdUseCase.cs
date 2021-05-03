using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;

namespace Schedule.Application.UseCases.Lending.GetLendingId
{
    public interface IGetLendingIdUseCase
    {
        Task<Result<LendingDto>> Execute(int id);
    }
}
