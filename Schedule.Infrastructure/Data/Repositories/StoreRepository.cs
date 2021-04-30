using System;
using System.Collections.Generic;
using System.Text;

using Schedule.Application.Dto;
using Schedule.Domain.Domain;
using Schedule.Application.Repositories;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Schedule.Infrastructure.Data.Repositories
{
    class StoreRepository : IStoreRepository
    {
        private readonly string connectionString;
        public StoreRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Schedules> FindStoreAll()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string sql = @"select * from Schedule";
                    var result = db.Query<Schedules>(sql).ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
