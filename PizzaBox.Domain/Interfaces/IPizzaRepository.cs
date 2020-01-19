using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
    public interface IPizzaRepository<T>
    {
        IEnumerable<T> GetPizzas();
        void AddPizza(T pizzas);
        void ModifyPizza(T pizzas);
        void RemovePizza(int id); 
    }
}
