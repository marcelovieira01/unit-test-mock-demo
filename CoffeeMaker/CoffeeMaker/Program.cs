using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoffeeMaker.API;
using CoffeeMaker.Maintenance;

namespace CoffeeMaker
{
    class Program
    {
        static ICoffeeCountersManager coffeeMaker = new CoffeeCountersManager();
        static IMaintenanceManager maintanceManager = new MaintenanceManager();

        static void Main(string[] args)
        {
            int option = 0;

            do
            {
                PrintUI();

                var key = Console.ReadLine();
                if (Int32.TryParse(key, out option))
                {
                    if (option == 9)
                    {
                        coffeeMaker.ResetMaintenanceCounter();
                    }
                    else if (option > 0)
                    {
                        coffeeMaker.IncrementTotalCoffeeCounter();
                    }
                    else if (option == 0)
                    {
                        break;
                    }
                }

            } while (option != 0);

            Console.WriteLine("It was a pleasure to serve you. Bye bye...");
            Console.ReadKey();
        }

        private static void PrintUI()
        {
            var maintenanceState = maintanceManager.CheckForMaintenance();
            var counters = coffeeMaker.GetTotalCoffeeCounters();

            Console.Clear();
            Console.WriteLine("Expresso counter: {0} ; {1} since maintenance\r\n\r\n", 
                counters.TotalCoffees,
                counters.TotalCoffeesSinceLastMaintenance);

            Console.WriteLine("\t1 - Short expresso");
            Console.WriteLine("\t2 - Long expresso");
            Console.WriteLine("\t3 - Caffe latte\r\n\r\n");
            Console.WriteLine("\t9 - Do maintenance\r\n\r\n");

            if (maintenanceState != MaintenanceState.OK)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                
                if(maintenanceState == MaintenanceState.ContractExpired)
                    Console.WriteLine("!! Your maintenance contract has expired. Please renew !!\r\n");
                else 
                    Console.WriteLine("!! Your coffee maker needs maintanance !!\r\n");

                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine("\t0 - QUIT");

        }
    }
}
