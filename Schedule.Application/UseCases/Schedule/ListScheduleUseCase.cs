using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;
using Schedule.Domain.Domain;

namespace Schedule.Application.UseCases.Schedule
{
    class ListScheduleUseCase : IListScheduleUseCase
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ListScheduleUseCase(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Result<List<ScheduleDataDto>>> Execute(int pageNumber, int rowsPerPage, string search)
        {
            var result = new Result<List<ScheduleDataDto>>();

            try
            {
                List<ScheduleDataDto> schedules = _scheduleRepository.ListSchedules(pageNumber, rowsPerPage, search);

                if(schedules == null)
                {
                    return result = new Result<List<ScheduleDataDto>>
                    {
                        Message = "Nenhuma contato cadastrado!",
                        Sucess = false
                    };
                }

                return result = new Result<List<ScheduleDataDto>>
                {
                    Message = "Consulta realizada com sucesso!",
                    Sucess = true,
                    Total = schedules.Count > 0 ? schedules.Select(x => x.TotalCount).FirstOrDefault() : 0,
                    TotalInPage = schedules.Count,
                    Data = schedules
                };
            }
            catch (Exception ex)
            {
                return result = new Result<List<ScheduleDataDto>>
                {
                    Message = "Erro",
                    Sucess = false
                };
            }
        }
    }
}
