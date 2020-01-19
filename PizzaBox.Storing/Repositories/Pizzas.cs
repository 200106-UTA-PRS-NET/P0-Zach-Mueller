
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Repositories

{
    class Pizzas
    {
        public int PizzaId { get; set; }
        public string Crust { get; set; }
        public string Size { get; set; }
        public string Username { get; set; }
        public decimal Price { get; set; }

        public virtual Repositories.User UsernameNavigation { get; set; }
    }
}
