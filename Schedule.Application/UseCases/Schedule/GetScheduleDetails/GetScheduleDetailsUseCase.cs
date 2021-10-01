using System;
using System.Collections.Generic;
using System.Text;
using Schedule.Application.Repositories;
using Schedule.Application.Dto;
using System.Threading.Tasks;

namespace Schedule.Application.UseCases.Schedule.GetScheduleDetails
{
    public sealed class GetScheduleDetailsUseCase : IGetScheduleDetailsUseCase
    {
        private readonly IScheduleRepository _scheduleRepository;

        public GetScheduleDetailsUseCase(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Result<ScheduleDto>> Execute(int id)
        {
            var result = new Result<ScheduleDto>();

            try
            {
                ScheduleDto agenda = await _scheduleRepository.GetDetails(id);

                if(agenda == null)
                {
                    return result = new Result<ScheduleDto>
                    {
                        Message = "Erro",
                        Sucess = false
                    };
                }

                return result = new Result<ScheduleDto>
                {
                    Message = "Sucesso",
                    Sucess = true,
                    Data = agenda
                   
                };
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
