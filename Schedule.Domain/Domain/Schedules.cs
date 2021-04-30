using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Domain.Domain
{
    public class Schedules
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public Schedules() { }

        public static Schedules Load(int Id, string Name, string Telephone, string Email)
        {
            Schedules schedule = new Schedules();

            Id = schedule.Id;
            Name = schedule.Name;
            Telephone = schedule.Telephone;
            Email = schedule.Email;

            return schedule;
        }
    }
}
