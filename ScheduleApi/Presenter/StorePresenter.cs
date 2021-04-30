using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Schedule.Application.Dto;
using ScheduleApi.Controllers.Serialization;
using System.Net;



namespace ScheduleApi.Presenter
{
    public class StorePresenter
    {
        public JsonContentResult ContentResult { get; }

        public StorePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void PopulateFirst(ResponseMessageDto<List<ScheduleDto>> dto)
        {
            if (dto == null)
            {
                ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
                return;
            }

            ContentResult.StatusCode = (int)(HttpStatusCode.OK);
            ContentResult.Content = JsonSerializer.SerializeObject(dto);
        }
    }
}
