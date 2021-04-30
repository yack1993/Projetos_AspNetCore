﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedule.Application.Dto;

namespace Schedule.Application.Repositories
{
    public interface ILendingRepository
    {
        List<LendingDto> Get(int id);
        List<LendingDto> All();
        Task<int> AddLending(LendingDto lending);
    }
}
