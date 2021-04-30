using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Schedule.Application.Dto;
using Schedule.Domain.Domain;

namespace Schedule.Application.UseCases.Schedule.UpdateSchedule
{
    public interface IUpdateScheduleUseCase
    {
        Task<Result> Execute(ScheduleDto schedule);
    }
}
