using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;

namespace Schedule.Application.UseCases.Schedule.GetSchedule
{
    public sealed class GetScheduleUseCase : IGetSheduleUseCse
    {
        private readonly IScheduleRepository _scheduleRepository;

        public GetScheduleUseCase(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

       public async Task<Result<List<ScheduleDto>>> Execute()
        {
            var result = new Result<List<ScheduleDto>>();
            try
            {
                var agenda = await _scheduleRepository.Get();

                if(agenda == null)
                {
                    return result = new Result<List<ScheduleDto>>
                    {
                        Message = "Nenhum contato encontrado",
                        Sucess = false
                    };
                }

                return result = new Result<List<ScheduleDto>>
                {
                    Message = "Sucesso",
                    Data = agenda,
                    Sucess = true
                };
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
