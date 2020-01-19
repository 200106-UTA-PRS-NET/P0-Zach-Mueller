using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Orders>();
        }

        public string StoreName { get; set; }
        public string Venue { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
