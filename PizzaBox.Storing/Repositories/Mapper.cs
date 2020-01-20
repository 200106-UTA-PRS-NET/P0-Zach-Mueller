using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
    class Mapper
    {
        public static PizzaBox.Storing.Repositories.Pizzas Map(Domain.Pizzas pizza)
        {
            return new PizzaBox.Storing.Repositories.Pizzas()
            {
                PizzaId = pizza.PizzaId,
                Crust = pizza.Crust,
                Size = pizza.Size,
                Username = pizza.Username,
                Price = pizza.Price
            };

        }

        public static Domain.Pizzas Map(Storing.Repositories.Pizzas pizza)
        {
            return new Domain.Pizzas()
            {
                PizzaId = pizza.PizzaId,
                Crust = pizza.Crust,
                Size = pizza.Size,
                Username = pizza.Username,
                Price = pizza.Price
            };
        }

        public static Storing.Repositories.Orders Map(Domain.Orders order)
        {
            return new Storing.Repositories.Orders()
            { 
                OrderId = order.OrderId,
                TotalCharges = order.TotalCharges,
              //  PlacedAt = order.PlacedAt,
                Username = order.Username,
                StoreName = order.StoreName,

            };
        }

        public static Domain.Orders Map(Storing.Repositories.Orders order)
        {
            return new Domain.Orders()
            {
                OrderId = order.OrderId,
                TotalCharges = order.TotalCharges,
              //  PlacedAt = order.PlacedAt,
                Username = order.Username,
                StoreName = order.StoreName,

            };
        }

        public static Storing.Repositories.Store Map(Domain.Store store)
        { 
            return new Storing.Repositories.Store()
                { 
                    StoreName = store.StoreName,
                    Venue = store.Venue
                    
                };
        }

        public static Domain.Store Map(Storing.Repositories.Store store)
        {
            return new Domain.Store()
            {
              
                StoreName = store.StoreName,
                Venue = store.Venue

            };
        }

        public static Storing.Repositories.User Map(Domain.User user)
        {
            return new Storing.Repositories.User()
            {
               
                Pass = user.Pass,   
                Username = user.Username

            };
        }

        public static Domain.User Map(Storing.Repositories.User user)
        {
            return new Domain.User()
            {
                
                Pass = user.Pass,
                Username = user.Username

            };
        }

        public static Storing.Repositories.CompletedOrders Map(Domain.CompletedOrders completedOrder)
        {
            return new Storing.Repositories.CompletedOrders()
            {
                
                OrderId = completedOrder.OrderId

            };
        }

        public static Domain.CompletedOrders Map(Storing.Repositories.CompletedOrders completedOrder)
        {
            return new Domain.CompletedOrders()
            {
                
                OrderId = completedOrder.OrderId

            };
        }
        
    }
}

