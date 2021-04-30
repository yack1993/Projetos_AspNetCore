using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;

namespace Schedule.Application.UseCases.Schedule
{
    public interface IListScheduleUseCase
    {
        Task<Result<List<ScheduleDataDto>>> Execute(int pageNumber, int rowsPerPage, string search);
    }
}
