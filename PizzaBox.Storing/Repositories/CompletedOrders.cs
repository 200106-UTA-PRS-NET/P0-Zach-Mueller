using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Repositories
{
    class CompletedOrders
    {
        public int OrderId { get; set; }

        public virtual Orders Order { get; set; }
    }
}
