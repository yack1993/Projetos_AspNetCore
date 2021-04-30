using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Application.Dto
{
    public class Result<T>
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public int Total { get; set; }
        public int TotalInPage { get; set; }
        public T Data { get; set; }

    }

    public class Result
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
    }
    public class ResponseMessageDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class ResponseMessageDto<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
