using System;
using System.Collections.Generic;
using System.Text;

using Schedule.Application.Dto;

namespace Schedule.Application.UseCases.Lending.GetLedingReturned
{
    public interface IGetLedingReturnedUseCase
    {
        Result<List<LendingDto>> Execute();
    }
}
