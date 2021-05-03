using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;

namespace Schedule.Infrastructure.Data.Repositories
{
    class LendingRepository : ILendingRepository
    {
        private readonly string connectionString;

        public LendingRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public LendingDto Get(int id)
        {
            try
            {
                using(IDbConnection db = new SqlConnection(connectionString))
                {
                    string sql = @"select * from tblEmprestimo where id = @Id";

                    var result = db.Query<LendingDto>(sql, new { id = id }).FirstOrDefault();

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
