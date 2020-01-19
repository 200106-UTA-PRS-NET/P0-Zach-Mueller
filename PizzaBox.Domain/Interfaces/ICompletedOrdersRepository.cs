using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
   public interface ICompletedOrdersRepository<T>
    {
        IEnumerable<T> GetCompletedOrders();
        void AddCompletedOrder(T completedOrder);
        void ModifyCompletedOrder(T completedOrder);
        void RemoveCompletedOrder(int id);
    }
}
