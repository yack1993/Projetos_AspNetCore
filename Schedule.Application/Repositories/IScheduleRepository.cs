using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;

using Schedule.Domain.Domain;

namespace Schedule.Application.Repositories
{
    public interface IScheduleRepository
    {
        List<ScheduleDataDto> ListSchedules(int pageNumber, int rowsPerPage, string search);
        //Task<ScheduleDto> AddSchedule(ScheduleDto scheduleDto);
        Task<int> AddSchedule(ScheduleDto schedule);
        Task<int> Update(ScheduleDto schedule);
        Task<int> Delete(int id);
    }
}
