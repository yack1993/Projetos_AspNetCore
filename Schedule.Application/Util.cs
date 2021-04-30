using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Application
{
    public class Util
    {
        public string AddZeroToDate(string date)
        {
            if (date.Split("/")[0].Length == 1 || date.Split("/")[1].Length == 1)
            {
                if (date.Split("/")[0].Length == 1)
                {
                    date = date.Split("/")[0].Replace(date.Split("/")[0], "0" + date.Split("/")[0] + "/" + date.Split("/")[1] + "/" + date.Split("/")[2]);
                }

                if (date.Split("/")[1].Length == 1)
                {
                    date = date.Split("/")[1].Replace(date.Split("/")[1], date.Split("/")[0] + "/0" + date.Split("/")[1] + "/" + date.Split("/")[2]);
                }
            }

            return date;
        }
    }
}
