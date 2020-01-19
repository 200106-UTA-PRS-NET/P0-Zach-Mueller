using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Repositories
{
    class Orders
    {
        public int OrderId { get; set; }
        public decimal TotalCharges { get; set; }
        public DateTime PlacedAt { get; set; }
        public string Username { get; set; }
        public string StoreName { get; set; }

        public virtual Store StoreNameNavigation { get; set; }
        public virtual User UsernameNavigation { get; set; }
        public virtual CompletedOrders CompletedOrders { get; set; }
    }
}
