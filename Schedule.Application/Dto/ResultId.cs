using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Application.Dto
{
    public class ResultId<T>
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public class ResultId
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
    }
}
