using System;
using System.Collections.Generic;
using System.Text;

using Schedule.Application.Dto;
using Schedule.Domain.Domain;
using Schedule.Application.Repositories;
using AutoMapper;
using System.Threading.Tasks;

namespace Schedule.Application.UseCases.Schedule.UpdateSchedule
{
    public sealed class UpdateScheduleUseCase : IUpdateScheduleUseCase
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public UpdateScheduleUseCase(IScheduleRepository scheduleRepository,
               IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public async Task<Result> Execute(ScheduleDto schedule)
        {
            try
            {
                var obj = _mapper.Map<ScheduleDto>(schedule);
                int up = await _scheduleRepository.Update(obj);

                var resul = new Result
                {
                    Message = up == 0 ? "Error" : "Update whith sucess",
                    Sucess = up == 0 ? false : true
                };

                return resul;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
