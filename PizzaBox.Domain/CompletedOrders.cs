using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public partial class CompletedOrders
    {
        public int OrderId { get; set; }

        public virtual Orders Order { get; set; }
    }
}
