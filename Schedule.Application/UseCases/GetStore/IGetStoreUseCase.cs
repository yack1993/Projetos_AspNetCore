using System;
using System.Collections.Generic;
using System.Text;

using Schedule.Domain.Domain;
using Schedule.Application.Dto;
using System.Threading.Tasks;

namespace Schedule.Application.UseCases.GetStore
{
    public interface IGetStoreUseCase
    {
        Task<ResponseMessageDto<List<ScheduleDto>>> Execute();
    }
}
