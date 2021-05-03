using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Schedule.Application.Dto;
using ScheduleApi.Controllers.Serialization;

namespace ScheduleApi.Presenter
{
    public class LendingPresenter
    {
        public JsonContentResult ContentResult { get; }

        public LendingPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Populate(Result<LendingDto> dto)
        {
            if (dto == null)
            {
                ContentResult.StatusCode = (int)(HttpStatusCode.BadRequest);
                ContentResult.Content = JsonSerializer.SerializeObject(dto);
                return;
            }

            ContentResult.StatusCode = (int)(HttpStatusCode.OK);
            ContentResult.Content = JsonSerializer.SerializeObject(dto);
        }
    }
}
