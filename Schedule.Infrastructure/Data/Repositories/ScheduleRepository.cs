using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;
using Npgsql;

namespace Schedule.Infrastructure.Data.Repositories
{
    class ScheduleRepository : IScheduleRepository
    {
        private readonly string connectionString;

        public ScheduleRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<ScheduleDto> GetDetails(int id)
        {
            try
            {
                using(IDbConnection db = new NpgsqlConnection(connectionString))
                {
                    string sql = @"Select Id, Name, Telephone, Email, Birthday from Schedule WHERE Id = @Id";

                    var result = db.Query<ScheduleDto>(sql, new { Id = id}).FirstOrDefault();

                    return result;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<List<ScheduleDto>> Get()
        {
            try
            {
                using(IDbConnection db = new NpgsqlConnection(connectionString))
                {
                    string sql = @"Select Id, Name, Telephone, Email, Birthday from Schedule order by birthday desc";

                    var result = db.Query<ScheduleDto>(sql).ToList();

                    return result;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public List<ScheduleDataDto> ListSchedules(int pageNumber, int rowsPerPage, string search)
        {
            try
            {
                if (search == null) search = "";

                pageNumber = pageNumber < 1 ? 1 : pageNumber;
                rowsPerPage = rowsPerPage < 1 ? 1 : rowsPerPage;

                using (IDbConnection db = new NpgsqlConnection(connectionString))
                {
                    string sql = @"[DECLARE @PageNumber AS INT, @RowspPage AS INT, @Search as varchar(max)
                                    SET @PageNumber = @Pn
                                   SET @RowspPage = @Rp
                                   SET @Search = @Na]
                                    
                                Select Id, Name, Telephone, Email, Birthday, TotalCount = Count(*) Over() from Schedule
                                where Id like '%' + @Search +'%' and Name like '%' + @Search +'%' and Email like '%' + @Search +'%'
                                order by Name desc OFFSET @RowspPage * (@PageNumber - 1) ROWS FETCH NEXT @RowspPage ROWS ONLY ";
                    var result = db.Query<ScheduleDataDto>(sql, new { Pn = pageNumber, Rp = rowsPerPage, Na = search }).ToList();

                    return result;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<int> AddSchedule(ScheduleDto schedule)
        {
            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                try
                {
                    string insertScheduleSql = @"insert into Schedule (Name, Telephone, Email, Birthday) 
                    Values(@Name, @Telephone, @Email, @Birthday); SELECT currval(pg_get_serial_sequence('Schedule','id'))";

                    //SELECT CAST(SCOPE_IDENTITY() as int)
                    DynamicParameters scheduleParameters = new DynamicParameters();

                    scheduleParameters.Add("@Name", schedule.Name);
                    scheduleParameters.Add("@Telephone", schedule.Telephone);
                    scheduleParameters.Add("@Email", schedule.Email);
                    scheduleParameters.Add("@Birthday", schedule.Birthday);

                    var id = db.QueryAsync<int>(insertScheduleSql, scheduleParameters).Result;
                    return id.Single();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<int> Update(ScheduleDto schedule)
        {
            using(IDbConnection db = new NpgsqlConnection(connectionString))
            {
                db.Open();
                using(var transactionScope = db.BeginTransaction())
                {
                    try
                    {
                        string updateScheduleQuery = @"UPDATE Schedule SET Name = @Name,Telephone = @Telephone, Email = @Email WHERE Id = @Id";

                        db.Query<int>(updateScheduleQuery, new
                        {
                            Id = schedule.Id,
                            Name = schedule.Name,
                            Telephone = schedule.Telephone,
                            Email = schedule.Email
                        }, transactionScope);

                        transactionScope.Commit();
                    }
                    catch(Exception ex)
                    {
                        throw;
                    }
                    return schedule.Id;
                }

            }
      
        }

        public async Task<int> Delete(int id)
        {
            using(IDbConnection db = new NpgsqlConnection(connectionString))
            {
                try
                {
                    string deleteSql = @"Delete from Schedule  WHERE Id = @Id";
                    int rows = await db.ExecuteAsync(deleteSql, new { Id = id });

                    return rows;
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        }

    }
}
