using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Application.Dto
{
    public class ScheduleDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public string Birthday { get; set; }

        public int TotalCount { get; set; }

        public ScheduleDataDto() { }

        public ScheduleDataDto(ScheduleDataDto schedule)
        {
            Id = schedule.Id;
            Name = schedule.Name;
            Telephone = schedule.Telephone;
            Email = schedule.Email;
            TotalCount = schedule.TotalCount;
        }
    }
}
