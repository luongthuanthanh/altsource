using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize
              // Use Factory
                // Initial vendor
                MainProcess.Instance.Init();
            // Welcome 
            Console.WriteLine("Well come to the clothing store application");
            bool isContinueUsingApp = true;

            while (isContinueUsingApp)
            {
                // Choose your action
                Console.WriteLine("Are you looking to buy clothing? (Are you a customer (yes/no)?)");
                // Buy / Sell?
                var answer = Console.ReadLine();
                var isBuyer = MainProcess.Instance.IsAnsweringBuy(answer);
                var isCustomer = isBuyer;

                if (isCustomer)
                {
                    while (isBuyer) // Mean Customer Looking Clothes to Buy
                    {
                        bool isContinueToBuy = true;

                        MainProcess.Instance.ControlTheFlowBuying(isContinueToBuy, isBuyer);

                        // Summarize The Order && Show The Price
                        MainProcess.Instance.CalculateOrder();

                        Console.WriteLine("Is Everything corrected (yes/no)?");
                        answer = Console.ReadLine();
                        var isEverythingOk = MainProcess.Instance.IsAnsweringTheOrderCorrected(answer);
                        if (isEverythingOk)
                        {
                            MainProcess.Instance.CheckOut();
                            Console.WriteLine("Thank you customer! You are welcome!");
                            isBuyer = false;
                        }
                        else
                        {
                            MainProcess.Instance.ReturnTheOrder();
                            Console.WriteLine("Sorry! Maybe we miscalculated. Can you choose the cloth at the store again.");
                            isBuyer = true;
                        }
                    }
                }
                else // supply the clothe in store 
                {
                    var isContinueToBuyFromSupplier = true;
                    while (isContinueToBuyFromSupplier)
                    {
                        Console.WriteLine("Hello Supplier! I would like to buy");
                        var isContinueToBuy = true;
                        MainProcess.Instance.ControlTheFlowBuying(isContinueToBuy, isBuyer);

                        // Summarize The Order && Show The Price
                        MainProcess.Instance.CalculateOrderSupplier();

                        Console.WriteLine("Is Everything corrected (yes/no)?");
                        answer = Console.ReadLine();
                        var isEverythingOk = MainProcess.Instance.IsAnsweringTheOrderCorrected(answer);

                        if (isEverythingOk)
                        {
                            MainProcess.Instance.SupplyToTheStore();
                            Console.WriteLine("Thank you! See you again!");
                            isContinueToBuyFromSupplier = false;
                        }
                        else
                        {
                            MainProcess.Instance.ReturnTheOrderSupplier();
                            Console.WriteLine("Sorry! Maybe we miscalculated. Can you choose the cloth at the supplier again.");
                            isContinueToBuyFromSupplier = true;
                        }
                    }
                }

                Console.WriteLine("Do you want to continue using the app?");
                answer = Console.ReadLine();
                isContinueUsingApp = MainProcess.Instance.IsAnsweringContinueUseApp(answer);
            }           
        }
    }
}
