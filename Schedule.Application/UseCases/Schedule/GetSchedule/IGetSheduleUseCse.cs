using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;

namespace Schedule.Application.UseCases.Schedule.GetSchedule
{
    public interface IGetSheduleUseCse
    {
        Task<Result<List<ScheduleDto>>> Execute();
    }
}
