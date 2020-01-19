using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain;


namespace PizzaBox.Storing.Repositories 

{
    public class PizzaRepository : IPizzaRepository<PizzaBox.Domain.Pizzas>, IUserRepository<Domain.User>, IStoresRepository<Domain.Store>, ICompletedOrdersRepository<Domain.CompletedOrders>, IOrdersRepository<Domain.Orders>
    {
        OOPContext pdb;

        public PizzaRepository()
        {
            pdb = new OOPContext();
        }

        public PizzaRepository(OOPContext pdb)
        {
            this.pdb = pdb ?? throw new ArgumentNullException(nameof(pdb));
        }

        
public IEnumerable<Domain.Pizzas> GetPizzas()
        {
            var query = from e in pdb.Pizzas
                        select e;

            return query;
        }

        public void AddPizza(Domain.Pizzas pizzas)
        {
            if (pdb.Pizzas.Any(e => e.PizzaId == pizzas.PizzaId) || pizzas.PizzaId == null)
            {
                Console.WriteLine($"This pizza {pizzas.PizzaId} is already in production, please select another");
                return;
            }
            else
                pdb.Pizzas.Add(pizzas);
            pdb.SaveChanges();
        }

        public void ModifyPizza(Domain.Pizzas pizzas)
        {
            if (pdb.Pizzas.Any(e => e.PizzaId == pizzas.PizzaId))
            {
                var piz = pdb.Pizzas.FirstOrDefault(e => e.PizzaId == pizzas.PizzaId);
                piz.Crust = pizzas.Crust;
                piz.Size = pizzas.Size;
                pdb.Pizzas.Update(piz);
                pdb.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Account with username {pizzas.PizzaId} does not exists, please ensure credentials have been typed correctly");
            }
        }

        public void RemovePizza(int id)
        {
            var piz = pdb.Pizzas.FirstOrDefault(e => e.PizzaId == id);
            if (piz.PizzaId == id)
            {
                pdb.Remove(piz);
                pdb.SaveChanges();
            }
            else
            {
                Console.WriteLine($"pizza with id {id} was never made");
                return;
            }
        }

        public IEnumerable<Domain.User> GetUsers()
        {
            var query = from e in pdb.User
                        select e;

            return query;
        }

        public void AddUser(Domain.User user)
        {
            if (pdb.User.Any(e => e.Username == user.Username) || user.Username == null)
            {
                Console.WriteLine($"The username {user.Username} is already in use, please select another");
                return;
            }
            else

                pdb.User.Add(user);
            pdb.SaveChanges();
            Console.WriteLine("User added successfully");
        }

        public void AuthUser(Domain.User user)
        {
            if (pdb.User.Any(e => e.Username == user.Username) && pdb.User.Any(e => e.Pass == user.Pass))
            { Console.WriteLine($"User authenticated successfully. Welcome back {user.Username}"); }
            else
            { Console.WriteLine("Could not find a user with such credentials."); }
        }

        public void ModifyUser(Domain.User user)
        {
            if (pdb.User.Any(e => e.Username == user.Username))
            {
                var use = pdb.User.FirstOrDefault(e => e.Username == user.Username);
                use.Pass = user.Pass;
                pdb.User.Update(use);
                pdb.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Account with username {user.Username} does not exists, please ensure credentials have been typed correctly");
            }
        }

        public void RemoveUser(string user)
        {
            var use = pdb.User.FirstOrDefault(e => e.Username == user);
            if (use.Username == user)
            {
                pdb.Remove(use);
                pdb.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Employee with this Id {user} does not exists");
                return;
            }
        }

        public IEnumerable<Domain.Store> GetStores()
        {
            var query = from e in pdb.Store
                        select e;

            return query;
        }

        public void AddStore(Domain.Store store)
        {
            if (pdb.Store.Any(e => e.StoreName == store.StoreName) || store.StoreName == null)
            {
                Console.WriteLine($"The username {store.StoreName} is already in use, please select another");
                return;
            }
            else
                pdb.Store.Add(store);
            pdb.SaveChanges();
        }

        public void ModifyStore(Domain.Store store)
        {
            if (pdb.Store.Any(e => e.StoreName == store.StoreName))
            {
                var sto = pdb.Store.FirstOrDefault(e => e.StoreName == store.StoreName);
                sto.Venue = store.Venue;
                pdb.Store.Update(sto);
                pdb.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Account with username {store.StoreName} does not exists, please ensure credentials have been typed correctly");
            }
        }

        public void RemoveStore(string name)
        {
            var nam = pdb.Store.FirstOrDefault(e => e.StoreName == name);
            if (nam.StoreName == name)
            {
                pdb.Remove(nam);
                pdb.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Store with name {name} does not exist");
                return;
            }


        }

        public IEnumerable<Domain.CompletedOrders> GetCompletedOrders()
        {
            var query = from e in pdb.CompletedOrders
                        select e;

            return query;
        }

        public void AddCompletedOrder(Domain.CompletedOrders completedOrder)
        {
            if (pdb.CompletedOrders.Any(e => e.OrderId == completedOrder.OrderId) || completedOrder.OrderId == null)
            {
                Console.WriteLine($"The username {completedOrder.OrderId} is already in use, please select another");
                return;
            }
            else
                pdb.CompletedOrders.Add(completedOrder);
            pdb.SaveChanges();
        }

        public void ModifyCompletedOrder(Domain.CompletedOrders completedOrder)
        {
            if (pdb.CompletedOrders.Any(e => e.OrderId == completedOrder.OrderId))
            {
                var comp = pdb.CompletedOrders.FirstOrDefault(e => e.OrderId == completedOrder.OrderId);
               // comp.OrderId = comp.OrderId;
                pdb.CompletedOrders.Update(comp);
                pdb.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Account with username {completedOrder.OrderId} does not exists, please ensure credentials have been typed correctly");
            }
        }

        public void RemoveCompletedOrder(int id)
        {
            var use = pdb.CompletedOrders.FirstOrDefault(e => e.OrderId == id);
            if (use.OrderId == id)
            {
                pdb.Remove(use);
                pdb.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Completed orderId {id} does not exists");
                return;
            }
        }

        public IEnumerable<Domain.Orders> GetOrders()
        {
            var query = from e in pdb.Orders
                        select e;

            return query;
        }

        public void AddOrders(Domain.Orders orders)
        {
            if (pdb.Orders.Any(e => e.OrderId == orders.OrderId) || orders.OrderId == null)
            {
                Console.WriteLine($"The order {orders.OrderId} is already being processed");
                return;
            }
            else
                pdb.Orders.Add(orders);
            pdb.SaveChanges();
        }

        public void ModifyOrders(Domain.Orders orders)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrders(int id)
        {
            throw new NotImplementedException();
        }
    }
}
