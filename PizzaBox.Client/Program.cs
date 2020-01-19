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

            //Main Menu
            CustomerOptions:
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1: Place an Order");
            Console.WriteLine("2: View Order History");
            Console.WriteLine("3: View store locations");
            Console.WriteLine("4: Signout");

            ConsoleKeyInfo customerChoice;
            customerChoice = Console.ReadKey();
            Console.WriteLine("");

            if (customerChoice.Key == ConsoleKey.D1)
            {
                Console.WriteLine("At this time, our Arlington location is the only available venue.");
                Console.WriteLine("Okay to continue ordering from this location?");
                Console.WriteLine("Please type Y or N (return to main menu) to confirm");
                ConsoleKeyInfo venueCheck;
                venueCheck = Console.ReadKey();
                Console.WriteLine("");

                if (venueCheck.Key == ConsoleKey.Y)
                { Console.WriteLine(" "); }
                if (venueCheck.Key == ConsoleKey.N)
                { goto CustomerOptions; }

                pizzaSelect:
                Console.WriteLine("Please select a pizza type below");
                Console.WriteLine("Cheese: 1");
                Console.WriteLine("Pepperoni: 2");
                Console.WriteLine("Sausage: 3");
                Console.WriteLine("Supreme: 4");
                Console.WriteLine("Veggie: 5");
                Console.WriteLine("Meat Lovers: 6");
                ConsoleKeyInfo pizzaCheck;
                pizzaCheck = Console.ReadKey();
                Console.WriteLine("");



            }
            else if (customerChoice.Key == ConsoleKey.D2)
            {
                Console.WriteLine($"Displaying order history for user {currentUser}");
            }
            else if (customerChoice.Key == ConsoleKey.D3)
            {
                PR.GetStores();
                Console.WriteLine("As of right now, Arlington is our only location.");
                Console.WriteLine("We do have plans to open up a new location in Denver within a few months.");
            }
            else if (customerChoice.Key == ConsoleKey.D4)
            {
                Console.WriteLine("Signing you out.");
                Console.WriteLine("We hope to serve you again soon");
                Environment.Exit(0);
            }

            else
            {
                Console.WriteLine("Only acceptable choices are 1-4");
                goto CustomerOptions;
            }
        }
    }
}
