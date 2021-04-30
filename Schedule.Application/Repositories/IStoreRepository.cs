using System;
using System.Collections.Generic;
using System.Text;

using Schedule.Domain.Domain;
using Schedule.Application;

namespace Schedule.Application.Repositories
{
    public interface IStoreRepository
    {
        List<Schedules> FindStoreAll();
    }
}
