using System;
using PizzaBox.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Storing;

namespace PizzaBox.Client
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Json Config
            var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = configBuilder.Build();


            var optionsBuilder = new DbContextOptionsBuilder<OOPContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaSettings"));
            var options = optionsBuilder.Options;

            PizzaBox.Storing.Repositories.PizzaRepository PR = new PizzaBox.Storing.Repositories.PizzaRepository();

            //And so it begins

            //Text to welcome and guide the user

            Console.WriteLine("Thank you for choosing OOP - Object Oriented Pizza.");
            Console.WriteLine("New users can register here - if you already have an account, login at this time.");
            Console.WriteLine(" ");

            //Login Procedure
            choicefail: 
            Console.WriteLine("Login: 1");
            Console.WriteLine("Register: 2");
            ConsoleKeyInfo LogReg;
            LogReg = Console.ReadKey();
            Console.WriteLine("");

            string currentUser;
            //Returning User
            if (LogReg.Key == ConsoleKey.D1)
            {
                Console.WriteLine("Enter Username: ");
                currentUser = Console.ReadLine();

                Console.WriteLine("Enter Password: ");
                string currentPass = Console.ReadLine();


                User person = new User() { Username = currentUser, Pass = currentPass };
                PR.AuthUser(person);


            }

            
            //New User
            else if (LogReg.Key == ConsoleKey.D2)
            {
                Console.WriteLine("Enter a desired username: ");
                string desiredUser = Console.ReadLine();


                Console.WriteLine("Enter a password: ");
                string desiredPass = Console.ReadLine();


                User person = new User() { Username = desiredUser, Pass = desiredPass };
                PR.AddUser(person);



                Console.WriteLine("Enter Username: ");
                 currentUser = Console.ReadLine();

                Console.WriteLine("Enter Password: ");
                string currentPass = Console.ReadLine();
                Console.WriteLine("");

                User newPerson = new User() { Username = currentUser, Pass = currentPass };
                PR.AuthUser(newPerson);
            }

            else
            { Console.WriteLine("Only acceptable choices are '1' and '2'");
                goto choicefail;
            }
            int hasOrderedToday = 0;
        MainMenu:
            //Main Menu
            
        CustomerOptions:
            Console.WriteLine("");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1: Place an Order");
            Console.WriteLine("2: View Order History");
            Console.WriteLine("3: View store locations");
            Console.WriteLine("4: Signout");
            Console.WriteLine("5: View Store Orders (Admin only)");

            ConsoleKeyInfo customerChoice;
            customerChoice = Console.ReadKey();
            Console.WriteLine("");

            if (customerChoice.Key == ConsoleKey.D1)
            {
                
                
                
             var ordGet = PR.GetOrders();
                 foreach (var ord in ordGet)
                 {
                    if (ord.PlacedAt == DateTime.Today.ToString("dd-MM-yyyy"))
                    {
                        Console.WriteLine("Our systems detect that you have already ordered today. Try again tomorrow.");
                        goto MainMenu;
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                 }

                    
                

                Console.WriteLine("");
                Console.WriteLine("NOTICE: WE LIMIT CUSTOMERS TO ONE ORDER DAILY, CAPPED AT $250 PER.");
                Console.WriteLine("");
                Console.WriteLine("At this time, our Arlington location is the only available venue.");
                Console.WriteLine("Okay to continue ordering from this location?");
                Console.WriteLine("Please type Y or N (return to main menu) to confirm");
                ConsoleKeyInfo venueCheck;
                venueCheck = Console.ReadKey();
                Console.WriteLine("");

                if (venueCheck.Key == ConsoleKey.Y)
                { Console.WriteLine(" "); }
                else if (venueCheck.Key == ConsoleKey.N)
                { goto CustomerOptions; }

                //Declaring variables for the BIG input mess below
                string pizzaType;
                string crustType;
                string pizzaSize;
                decimal charges = 0;
                decimal price = 0;
                ConsoleKeyInfo crustCheck;
                ConsoleKeyInfo pizzaCheck;
                ConsoleKeyInfo sizeCheck;
                ConsoleKeyInfo additionalPizzaCheck;


            pizzaSelect:

                //Pizza Selection menu
                Console.WriteLine("");
                Console.WriteLine("Please select a pizza type below");
                Console.WriteLine("Cheese: 1");
                Console.WriteLine("Pepperoni: 2");
                Console.WriteLine("Sausage: 3");
                Console.WriteLine("Supreme: 4");
                Console.WriteLine("Veggie: 5");
                Console.WriteLine("Meat Lover's: 6");

                pizzaCheck = Console.ReadKey();
                Console.WriteLine("");

                //Case statements for each pizza type
                if (pizzaCheck.Key == ConsoleKey.D1)
                {
                    pizzaType = "Cheese";
                    Console.WriteLine("Cheese selected");
                }

                else if (pizzaCheck.Key == ConsoleKey.D2)
                {
                    pizzaType = "Pepperoni";
                    Console.WriteLine("Pepperoni Selected");
                }

                else if (pizzaCheck.Key == ConsoleKey.D3)
                {
                    pizzaType = "Sausage";
                    Console.WriteLine("Sausage Selected");
                }

                else if (pizzaCheck.Key == ConsoleKey.D4)
                {
                    pizzaType = "Supreme";
                    Console.WriteLine("Supreme Selected");
                }

                else if (pizzaCheck.Key == ConsoleKey.D5)
                {
                    pizzaType = "Veggie";
                    Console.WriteLine("Veggie Selected");
                }

                else if (pizzaCheck.Key == ConsoleKey.D6)
                {
                    pizzaType = "Meat Lovers";
                    Console.WriteLine("Meat Lover's Selected");
                }
                else
                {
                    Console.WriteLine("Please choose a valid option 1-6");
                    goto pizzaSelect;
                }

            crustSelect:
                Console.WriteLine("");
                Console.WriteLine("Now select your crust type. It has no baring on price.");
                Console.WriteLine("Classic: 1");
                Console.WriteLine("Flatbread: 2");
                Console.WriteLine("Cheese stuffed: 3");
                Console.WriteLine("Hand Tossed: 4");


                crustCheck = Console.ReadKey();
                Console.WriteLine("");

                if (crustCheck.Key == ConsoleKey.D1)
                { crustType = "Classic"; }
                else if (crustCheck.Key == ConsoleKey.D2)
                { crustType = "Flatbread"; }
                else if (crustCheck.Key == ConsoleKey.D3)
                { crustType = "Cheese Stuffed"; }
                else if (crustCheck.Key == ConsoleKey.D4)
                { crustType = "Hand Tossed"; }
                else
                {
                    Console.WriteLine("Please choose a valid option 1-4");
                    goto crustSelect;
                }

            sizeSelect:
                Console.WriteLine("");
                Console.WriteLine("Select the size of this pizza");
                Console.WriteLine("Small ($8): 1");
                Console.WriteLine("Medium ($12): 2");
                Console.WriteLine("Large($15): 3");

                sizeCheck = Console.ReadKey();
                Console.WriteLine("");

                if (sizeCheck.Key == ConsoleKey.D1)
                {
                    charges += 8;
                    price = 8;
                    pizzaSize = "small";
                }
                else if (sizeCheck.Key == ConsoleKey.D2)
                {
                    charges += 12;
                    price = 12;
                    pizzaSize = "Medium";
                }
                else if (sizeCheck.Key == ConsoleKey.D3)
                {
                    charges += 15;
                    price = 15;
                    pizzaSize = "Large";
                }
                else
                {
                    Console.WriteLine("Please choose a valid option 1-3");
                    goto sizeSelect;
                }

                if (charges > 250)
                {
                    Console.WriteLine("Pizza cannot be added as it would take total order over $250.");
                    Console.WriteLine("Please submit order as is or cancel. Current order will be lost if cancelled.");
                    Console.WriteLine("submit order as is?");
                    ConsoleKeyInfo submit;
                    submit = Console.ReadKey();
                    if (submit.Key == ConsoleKey.Y)
                    { goto OrderSubmission; }
                    if (submit.Key == ConsoleKey.N)
                    {
                        charges = 0;
                        goto MainMenu;
                    }

                }
                Pizzas delicacy = new Pizzas() { Crust = crustType, Size = pizzaSize, Username = currentUser, PizzaType = pizzaType, Price = price };
                PR.AddPizza(delicacy);

                Console.WriteLine("Pizza added successfully. Add another to this order?");
                Console.WriteLine("Please be aware that we cap all orders at $250 for supply reasons.");
                Console.WriteLine("Please enter Y or N (submit order)");
                additionalPizzaCheck = Console.ReadKey();
                Console.WriteLine("");

                if (additionalPizzaCheck.Key == ConsoleKey.Y)
                { goto pizzaSelect; }
                if (additionalPizzaCheck.Key == ConsoleKey.N)
                { Console.WriteLine(""); }

            //Order submission
            OrderSubmission:
                Console.WriteLine("Order is now being submitted and will be prepared shortly.");
                string venue = "Object Oriented Pizza";
                string today = DateTime.Today.ToString("dd-MM-yyyy");
                
                string placedAt = $"{today}";

                Orders orderup = new Orders() { TotalCharges = charges, PlacedAt = placedAt, Username = currentUser, StoreName = venue };
                PR.AddOrders(orderup);
                Console.WriteLine("");
                Console.WriteLine("Returning to main menu.");
                hasOrderedToday = 1;
                goto MainMenu;

            }
            else if (customerChoice.Key == ConsoleKey.D2)
            {
                Console.WriteLine("");
                Console.WriteLine($"Displaying order history for user {currentUser}");

                var ordGet = PR.GetOrders();
                foreach (var ord in ordGet)
                {
                    if (ord.Username == currentUser)
                        Console.WriteLine($"{ord.OrderId}: ${ord.TotalCharges}, {ord.PlacedAt}, {ord.Username}, {ord.StoreName}");
                    else
                        Console.WriteLine("Could not find any orders placed under your username.");
                }
                Console.WriteLine("");
                Console.WriteLine("Returning to main menu.");
                goto MainMenu;
            }
            else if (customerChoice.Key == ConsoleKey.D3)
            {
                Console.WriteLine("");
                var locGet = PR.GetStores();
                foreach (var loc in locGet)
                {
                    if (loc.StoreName != null)
                    { Console.WriteLine($"{loc.StoreName}, {loc.Venue}"); }
                    else
                    { Console.WriteLine("Something done-diddly messed up"); }
                }
                Console.WriteLine("");
                Console.WriteLine("As of right now, Arlington is our only location.");
                Console.WriteLine("We do have plans to open up a new location in Denver within a few months.");
            }
            else if (customerChoice.Key == ConsoleKey.D4)
            {
                Console.WriteLine("Signing you out.");
                Console.WriteLine("We hope to serve you again soon");
                Environment.Exit(0);
            }

            else if (customerChoice.Key == ConsoleKey.D5)
            {
            Retry:
                Console.WriteLine("");
                Console.WriteLine("Attempting to access store order history.");
                Console.WriteLine("Please enter your location's security phrase at this time.");
                
                string codeEntry = Console.ReadLine();
                string passCode = "OOP0412";

                if (codeEntry == passCode)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Fetching order data for your location.");
                    var ordGet = PR.GetOrders();
                    foreach (var ord in ordGet)
                    {
                        if (ord.OrderId != null)
                            Console.WriteLine($"{ord.OrderId}: ${ord.TotalCharges}, {ord.PlacedAt}, {ord.Username}, {ord.StoreName}");
                        else
                            Console.WriteLine("Could not find any orders placed at your location.");
                    }

                }
                else
                { 
                    Console.WriteLine("Nuh-uh-uh, you didn't say the magic word!");
                    Seriously:
                    Console.WriteLine("1 to try again");
                    Console.WriteLine("2 to return to main menu");

                    ConsoleKeyInfo menuCheck;
                    menuCheck = Console.ReadKey();
                    Console.WriteLine("");

                    if (menuCheck.Key == ConsoleKey.D1)
                    { goto Retry; }
                    else if (menuCheck.Key == ConsoleKey.D2)
                    { goto MainMenu; }
                    else
                    { goto Seriously; }

                }
                Console.WriteLine("Returning to main menu.");
                goto MainMenu;
            }
            else
            {
                Console.WriteLine("Only acceptable choices are 1-5");
                goto CustomerOptions;
            }
        }
    }
}
