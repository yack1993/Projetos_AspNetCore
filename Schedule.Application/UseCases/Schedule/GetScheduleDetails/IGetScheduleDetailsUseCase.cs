using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;

namespace Schedule.Application.UseCases.Schedule.GetScheduleDetails
{
    public interface IGetScheduleDetailsUseCase
    {
        Task<Result<ScheduleDto>> Execute(int id);
    }
}
