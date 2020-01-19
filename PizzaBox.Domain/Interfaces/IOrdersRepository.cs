using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
    public interface IOrdersRepository<T>
    {
        IEnumerable<T> GetOrders();
        void AddOrders(T orders);
        void ModifyOrders(T orders);
        void RemoveOrders(int id);
    }
}
