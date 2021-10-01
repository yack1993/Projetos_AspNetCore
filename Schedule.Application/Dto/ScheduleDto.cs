using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Application.Dto
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }

        public ScheduleDto() { }

        public ScheduleDto(ScheduleDto schedule)
        {
            Id = schedule.Id;
            Name = schedule.Name;
            Telephone = schedule.Telephone;
            Email = schedule.Email;
            Birthday = schedule.Birthday;
        }
    }
}
