using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;
using Schedule.Domain.Domain;

namespace Schedule.Application.UseCases.Schedule.AddSchedule
{
    public sealed class AddScheduleUseCase : IAddScheduleUseCase
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public AddScheduleUseCase(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<ResultId> Execute(ScheduleDto schedule)
        {
            var message = string.Empty;
            //var result = new Result<ScheduleDto>();
            var result = new ResultId();

            try
            {
                if (schedule.Name == null || schedule.Telephone == null || schedule.Email == null || schedule.Birthday == null)
                {
                    if (schedule.Name == null)
                        message = "Por favor preencha seu nome";
                    else if (schedule.Telephone == null)
                        message = "Por favor preencha o seu telefone";
                    else if (schedule.Email == null)
                        message = "Por favor preencha o seu Email";
                    else if (schedule.Birthday == null)
                    {
                        message = "Por favor preencha a data do seu aniversário";
                    }

                    return result = new ResultId
                    {
                        Message = "Erro",
                        Sucess = false
                    };
                }


                int id = await _scheduleRepository.AddSchedule(schedule);

                result = new ResultId
                {
                    Message = id == 0 ? "Não foi possível cadastrar, por favor verifique!" : "Cadastrado com sucesso!",
                    Sucess = id == 0 ? false : true,
                    //Data = sch.Id == 0 ? null : schedule
                };
            }
            catch (Exception ex)
            {
                return result = new ResultId
                {
                  Message = "Erro!",
                  Sucess = false
                };
            }
            return result;
        }
    }
}
