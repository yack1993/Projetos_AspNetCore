using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Application.Dto
{
    public class StoreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StoreDto() { }

        public StoreDto(StoreDto store)
        {
            Id = store.Id;
            Name = store.Name;
        }
    }
}
