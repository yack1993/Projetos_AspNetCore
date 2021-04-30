using System;
using System.Collections.Generic;
using System.Text;

using Schedule.Application.Repositories;
using Schedule.Application.Dto;
using Schedule.Domain.Domain;
using System.Threading.Tasks;

namespace Schedule.Application.UseCases.GetStore
{
    public sealed class GetStoreUseCase : IGetStoreUseCase
    {
        private readonly IStoreRepository _storeRepository;

        public GetStoreUseCase(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<ResponseMessageDto<List<ScheduleDto>>> Execute()
        {
            var result = new ResponseMessageDto<List<ScheduleDto>>();

            try
            {
                List<Schedules> store = _storeRepository.FindStoreAll();

                if (store.Count > 0)
                {
                    result.Data = new List<ScheduleDto>();
                    result.Message = "Consulta Ok";
                    result.Success = true;

                    store.ForEach(q =>
                    {
                        result.Data.Add(new ScheduleDto
                        {
                            Id = q.Id,
                            Name = q.Name
                        });
                    });
                }
                else
                {
                    return result = new ResponseMessageDto<List<ScheduleDto>>
                    {
                        Message = "Não foi localizado nenhuma loja",
                        Success = false,
                        Data = null
                    };
                }
                return result;
            }
            catch (Exception ex)
            {
                //RegisterLog.Log("GetStoreUseCase", ex.TargetSite.DeclaringType.Namespace);
                return result = new ResponseMessageDto<List<ScheduleDto>>
                {
                    Message = "Erro de Processamento para retornar store",
                    Success = false,
                    Data = null
                };
            }

        }
    }
}
