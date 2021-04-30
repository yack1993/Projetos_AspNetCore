using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Application.Dto
{
    public class ItemLendingDto
    {
       public int Id { get; set; }
       public int IdLending { get; set; }
       public int Quantity { get; set; }
       public DateTime Devolotion { get; set; }

       public ItemLendingDto() { }
       public ItemLendingDto(ItemLendingDto item)
        {
            Id = item.Id;
            IdLending = item.IdLending;
            Quantity = item.Quantity;
            Devolotion = item.Devolotion;
        }
    }
}
