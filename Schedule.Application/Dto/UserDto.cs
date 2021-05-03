using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Application.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public UserDto() { }
        public UserDto(UserDto user)
        {
            Id = user.Id;
            Name = user.Name;
            RG = user.RG;
            CPF = user.CPF;
            Email = user.Email;
        }
    }
}
