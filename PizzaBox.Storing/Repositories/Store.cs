using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Repositories
{
    class Store
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
