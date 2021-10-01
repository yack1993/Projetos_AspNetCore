using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Schedule.Application.Dto;
using Schedule.Application.UseCases.Schedule;
using Schedule.Domain.Domain;
using ScheduleApi.Presenter;

using Schedule.Application.UseCases.Schedule.AddSchedule;
using Schedule.Application.UseCases.Schedule.UpdateSchedule;
using Schedule.Application.UseCases.Schedule.DeleteSchedule;
using Schedule.Application.UseCases.Schedule.GetSchedule;
using Schedule.Application.UseCases.Schedule.GetScheduleDetails;

namespace ScheduleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IListScheduleUseCase _listScheduleUseCase;
        private readonly IAddScheduleUseCase _addScheduleUseCase;
        private readonly IUpdateScheduleUseCase _updateScheduleUseCase;
        private readonly IDeleteScheduleUseCase _deleteScheduleUseCase;
        private readonly SchedulePresenter _schedulePresenter;
        private readonly IGetSheduleUseCse _getSheduleUseCse;
        private readonly IGetScheduleDetailsUseCase _getScheduleDetailsUseCase;


        public ScheduleController(IListScheduleUseCase listScheduleUseCase,
            IAddScheduleUseCase addScheduleUseCase,
            IUpdateScheduleUseCase updateScheduleUseCase,
            IDeleteScheduleUseCase deleteScheduleUseCase,
            SchedulePresenter schedulePresenter,
            IGetSheduleUseCse getSheduleUseCse,
            IGetScheduleDetailsUseCase getScheduleDetailsUseCase)
        {
            _listScheduleUseCase = listScheduleUseCase;
            _addScheduleUseCase = addScheduleUseCase;
            _updateScheduleUseCase = updateScheduleUseCase;
            _deleteScheduleUseCase = deleteScheduleUseCase;
            _schedulePresenter = schedulePresenter;
            _getSheduleUseCse = getSheduleUseCse;
            _getScheduleDetailsUseCase = getScheduleDetailsUseCase;

        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            Result<ScheduleDto> output = await _getScheduleDetailsUseCase.Execute(id);
            return Ok(output);
        }


        [HttpGet("All")]
        //[Route("AllEmployeeDetails")]
        public async Task<IActionResult> All()
        {
            Result<List<ScheduleDto>> output = await _getSheduleUseCse.Execute();
            return Ok(output);
        }

        /// <summary>
        /// Get an Store
        /// </summary>
        [HttpGet("ListShedule")]
        public async Task<IActionResult> ListShedule(int pageNumber, int rowsPerPage, string search)
        {
            Result<List<ScheduleDataDto>> output = await _listScheduleUseCase.Execute(pageNumber, rowsPerPage, search);
            _schedulePresenter.Populate(output);
            return _schedulePresenter.ContentResult;
        }

        /// <summary>
        /// Add an Product
        /// </summary>
        /// 
        [HttpPost]
        public async Task<IActionResult> Add(ScheduleDto schedule)
        {
            ResultId output = await _addScheduleUseCase.Execute(schedule);
            _schedulePresenter.Populate(output);
            return _schedulePresenter.ContentResult;
        }


        [HttpPut]
        public async Task<IActionResult> Update(ScheduleDto schedule)
        {
            Result output = await _updateScheduleUseCase.Execute(schedule);
            return Ok(output);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Result output = await _deleteScheduleUseCase.Execute(id);
            return Ok(output);
        }
    }
}
