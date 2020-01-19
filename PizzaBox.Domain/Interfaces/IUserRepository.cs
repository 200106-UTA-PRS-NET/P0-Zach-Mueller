using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
   public interface IUserRepository<T>
    {
        IEnumerable<T> GetUsers();
        void AddUser(T user);
        void ModifyUser(T user);
        void RemoveUser(string user);
    }
}
