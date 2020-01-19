using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
   public interface IStoresRepository<T>
    {
        IEnumerable<T> GetStores();
        void AddStore(T stores);
        void ModifyStore(T stores);
        void RemoveStore(string name); 
    }
}
