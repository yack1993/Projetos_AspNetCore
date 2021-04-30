using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Schedule.Application.Dto;
using ScheduleApi.Controllers.Serialization;
using System.Net;


namespace ScheduleApi.Presenter
{
    public class SchedulePresenter
    {
        public JsonContentResult ContentResult { get; }

        public SchedulePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Populate(Result<List<ScheduleDataDto>> dto)
        {
            if (dto == null)
            {
                ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
                return;
            }

            ContentResult.StatusCode = (int)(HttpStatusCode.OK);
            ContentResult.Content = JsonSerializer.SerializeObject(dto);
        }

        public void Populate(ResultId dto)
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
