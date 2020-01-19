using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Repositories
{
    internal class User
    {
        public User()
        {
            Orders = new HashSet<Orders>();
            Pizzas = new HashSet<Pizzas>();
        }

        public string Username { get; set; }
        public string Pass { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Pizzas> Pizzas { get; set; }
    }
}
