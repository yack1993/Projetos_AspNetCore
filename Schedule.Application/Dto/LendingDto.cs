using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Application.Dto
{
    public class LendingDto
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; }
        public DateTime DateLending { get; set; }
        public bool Returned { get; set; }

        public LendingDto() { }
        public LendingDto(LendingDto lending)
        {
            Id = lending.Id;
            IdUser = lending.IdUser;
            Name = lending.Name;
            DateLending = lending.DateLending;
            Returned = lending.Returned;
        }

    }
}
