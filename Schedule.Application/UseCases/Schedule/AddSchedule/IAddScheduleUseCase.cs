using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;

namespace Schedule.Application.UseCases.Schedule.AddSchedule
{
    public interface IAddScheduleUseCase
    {
        //Task<Result<ScheduleDto>> Execute(ScheduleDto schedule);
        Task<ResultId> Execute(ScheduleDto schedule);
    }
}
