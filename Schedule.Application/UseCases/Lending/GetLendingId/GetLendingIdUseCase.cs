using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;

namespace Schedule.Application.UseCases.Lending.GetLendingId
{
    public sealed class GetLendingIdUseCase : IGetLendingIdUseCase
    {
        private readonly ILendingRepository _lendingRepository;

        public GetLendingIdUseCase(ILendingRepository lendingRepository)
        {
            _lendingRepository = lendingRepository;
        }

        public async Task<Result<LendingDto>> Execute(int id)
        {
            var result = new Result<LendingDto>();

            try
            {
                LendingDto lending =  _lendingRepository.Get(id);

                if(lending == null)
                {
                    return result = new Result<LendingDto>
                    {
                        Message = "Nenhum item encontrado",
                        Sucess = false
                    };
                }

                return result = new Result<LendingDto>
                {
                    Message = "Ok",
                    Sucess = true,
                    Data = lending
                };

                //return result;
            }
            catch(Exception ex)
            {
                return result = new Result<LendingDto>
                {
                    Message = "Erro de processamento",
                    Sucess = false
                };
            }
        }
    }
}
