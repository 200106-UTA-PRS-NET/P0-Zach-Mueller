using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public partial class Pizzas
    {
        public int PizzaId { get; set; }
        public string Crust { get; set; }
        public string Size { get; set; }
        public string Username { get; set; }
        public string PizzaType { get; set; }
        public decimal Price { get; set; }

        public virtual User UsernameNavigation { get; set; }
    }
}
