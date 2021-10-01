using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Application.Dto
{
    public interface IBookstoreDatabaseSettings
    {
        string BooksCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
