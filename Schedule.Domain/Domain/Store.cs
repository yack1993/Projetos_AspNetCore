using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Domain.Domain
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Store() { }

        public static Store Load(int id, string name)
        {
            Store store = new Store();
            store.Id = id;
            store.Name = name;
            return store;
        }
    }
}
