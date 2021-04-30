using System;
using System.Collections.Generic;
using System.Text;

using Schedule.Application.Dto;
using Schedule.Domain.Domain;
using Schedule.Application.Repositories;
using AutoMapper;
using System.Threading.Tasks;


namespace Schedule.Application.UseCases.Schedule.DeleteSchedule
{
    public sealed class DeleteScheduleUseCase : IDeleteScheduleUseCase
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;


        public DeleteScheduleUseCase(IScheduleRepository scheduleRepository,
            IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public async Task<Result> Execute(int id)
        {
            try
            {
                int rownsAffectad = await _scheduleRepository.Delete(id);

                var resul = new Result
                {
                    Message = rownsAffectad == 0 ? "Error" : "Delete Successfull",
                    Sucess = rownsAffectad == 0 ? false : true
                };

                return resul;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}
