using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;
using Schedule.Application.UseCases.Lending.GetLendingId;
using ScheduleApi.Presenter;

namespace ScheduleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LendingController : ControllerBase
    {
        private readonly IGetLendingIdUseCase _getLendingIdUseCase;
        private readonly LendingPresenter _lendingPresenter;

        public LendingController(IGetLendingIdUseCase getLendingIdUseCase,
            LendingPresenter lendingPresenter)
        {
            _getLendingIdUseCase = getLendingIdUseCase;
            _lendingPresenter = lendingPresenter;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            Result<LendingDto> output = await _getLendingIdUseCase.Execute(id);
            _lendingPresenter.Populate(output);
            return _lendingPresenter.ContentResult;
        }
    }
}
