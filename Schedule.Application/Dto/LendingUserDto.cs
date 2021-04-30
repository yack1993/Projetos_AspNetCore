using System;
using System.Collections.Generic;
using System.Text;
using Schedule.Application.Dto;

namespace Schedule.Application.Dto
{
    public class LendingUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public LendingDto Lending { get; set; }
        public LendingUserDto() { }
        public LendingUserDto(LendingUserDto lendings)
        {
            Id = lendings.Id;
            Name = lendings.Name;
            RG = lendings.RG;
            CPF = lendings.CPF;
            Email = lendings.Email;
            Lending = lendings.Lending;
        }
    }
}
