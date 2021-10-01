using System;
using System.Collections.Generic;
using System.Text;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;

namespace Schedule.Application.UseCases.Lending.GetLedingReturned
{
    public sealed class GetLedingReturnedUseCase : IGetLedingReturnedUseCase
    {
        private readonly ILendingRepository _lendingRepository;

        public GetLedingReturnedUseCase(ILendingRepository lendingRepository)
        {
            _lendingRepository = lendingRepository;
        }

        public Result<List<LendingDto>> Execute()
        {
            var result = new Result<List<LendingDto>>();
            try
            {
                List<LendingDto> lendings = _lendingRepository.GetReturned();

                if(lendings == null || lendings.Count == 0)
                {
                    return result = new Result<List<LendingDto>>
                    {
                        Message = "Nenhum emprestimo devolvido!",
                        Sucess = false
                    };
                }

                return result = new Result<List<LendingDto>>
                {
                    Message = "Sucesso!",
                    Sucess = true,
                    Data = lendings
                };
            }
            catch(Exception ex)
            {
                return result = new Result<List<LendingDto>>
                {
                    Message = "Erro",
                    Sucess = false
                };
            }
        }
    }
}
