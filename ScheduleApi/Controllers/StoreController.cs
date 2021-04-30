using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Schedule.Application.Dto;
using Schedule.Application.UseCases.GetStore;
using ScheduleApi.Presenter;

namespace ScheduleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IGetStoreUseCase _getStoreUseCase;
        
        private readonly StorePresenter _storePresenter;
        public StoreController(IGetStoreUseCase getStoreUseCase,
            
            StorePresenter storePresenter)
        {
            _getStoreUseCase = getStoreUseCase;
            
            _storePresenter = storePresenter;
        }

        /// <summary>
        /// Get an Store
        /// </summary>
        [HttpGet("ListStore")]
        public async Task<IActionResult> ListStore()
        {
            ResponseMessageDto<List<ScheduleDto>> output = await _getStoreUseCase.Execute();
            _storePresenter.PopulateFirst(output);
            return _storePresenter.ContentResult;
        }

    }
}
