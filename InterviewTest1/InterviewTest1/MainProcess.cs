using InterviewTest1.Clothing;
using InterviewTest1.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest1
{
    public class MainProcess
    {
        #region Property
        private static MainProcess _process;

        private Supplier supplier = new Supplier(); // Use For Get Price
        private Customer customer = new Customer();

        private static Vendor vendor = new Vendor(new List<IClothing>()); // clothes at vendor machine

        private static List<IClothing> Clothes() => vendor.Clothes;

        private static List<IClothing> ClothesCustomerChoose = new List<IClothing>();

        private static List<IClothing> ClothesChooseAtSupplier = new List<IClothing>();

        private static List<IClothing> SupplierClothes;

        public static MainProcess Instance
        {
            get
            {
                if (_process == null)
                {
                    return new MainProcess();
                }

                return _process;
            }
        }

        #endregion

        #region Initialize Data

        public void Init()
        {
            var clothes = new List<IClothing>();

            // Suppose we have Each Kind Of TShirt Have 2 Quantitys In Store                        
            clothes.Add(new TShirt(size:"XL", color: "red",
                                    buyerPrice: supplier.SellTShirtAtPrice, 
                                    sellerPrice: customer.BuyTShirtAtPrice));
            clothes.Add(new TShirt(size: "L", color: "blue", 
                                    buyerPrice: supplier.SellTShirtAtPrice, 
                                    sellerPrice: customer.BuyTShirtAtPrice));

            // Suppose we have Each Kind Of Dress Shirt Have 2 Quantitys In Store                        
            clothes.Add(new DressShirt(size: "XL", color:"green", 
                                        buyerPrice: supplier.SellDressShirtAtPrice, 
                                        sellerPrice: customer.BuyDressShirtAtPrice));
            clothes.Add(new DressShirt(size: "L",  color: "yellow",
                                        buyerPrice: supplier.SellDressShirtAtPrice, 
                                        sellerPrice: customer.BuyDressShirtAtPrice));

            vendor = new Vendor(clothes);
            InitForSupplier();
        }

        public void InitForSupplier()
        {
            SupplierClothes = new List<IClothing>();

            // Suppose we have Each Kind Of TShirt Have 2 Quantitys In Store                        
            SupplierClothes.Add(new TShirt(size: "XL", color: "red",
                                    buyerPrice: supplier.SellTShirtAtPrice,
                                    sellerPrice: customer.BuyTShirtAtPrice));
            SupplierClothes.Add(new TShirt(size: "L", color: "blue",
                                    buyerPrice: supplier.SellTShirtAtPrice,
                                    sellerPrice: customer.BuyTShirtAtPrice));

            // Suppose we have Each Kind Of Dress Shirt Have 2 Quantitys In Store                        
            SupplierClothes.Add(new DressShirt(size: "XL", color: "green",
                                        buyerPrice: supplier.SellDressShirtAtPrice,
                                        sellerPrice: customer.BuyDressShirtAtPrice));
            SupplierClothes.Add(new DressShirt(size: "L", color: "yellow",
                                        buyerPrice: supplier.SellDressShirtAtPrice,
                                        sellerPrice: customer.BuyDressShirtAtPrice));

            
        }

        #endregion

        public void CalculateOrderSupplier()
        {
            HelperForDisplay(ClothesChooseAtSupplier, true);
            var sumPrice = ClothesChooseAtSupplier.Sum(x => x.Sell());
            var quantity = ClothesChooseAtSupplier.Count();

            Console.WriteLine("You buy: " + quantity + " clothes");
            Console.WriteLine("Here are the total price:" + sumPrice);
        }
        public void SupplyToTheStore()
        {
            vendor.Clothes.AddRange(ClothesChooseAtSupplier);
            ClothesChooseAtSupplier.Clear();
        }

        public void ReturnTheOrderSupplier()
        {
            ClothesChooseAtSupplier.Clear();
        }

        public void AddClothesFromTheSupplier(int index)
        {
            if (SupplierClothes.Any() == false)
                Console.WriteLine("Sorry! We are out of all the clothes in the store");

            var clothes = SupplierClothes.ElementAtOrDefault(index - 1);
            if (clothes == null)
            {
                Console.WriteLine("Sorry! The clothes you choose already sold");
            }

            ClothesChooseAtSupplier.Add(clothes);

            Console.WriteLine("You choose clothes :" + clothes.Show(true));
        }

        #region Action Buy

        public void CalculateOrder()
        {
            HelperForDisplay(ClothesCustomerChoose, true);
            var sumPrice = ClothesCustomerChoose.Sum(x => x.Sell());
            var quantity = ClothesCustomerChoose.Count();

            Console.WriteLine("You buy: " + quantity + " clothes");
            Console.WriteLine("Here are the total price:" + sumPrice);
        }

        /// <summary>
        /// Checkout or payment of the customer
        /// </summary>
        public void CheckOut()
        {
            ClothesCustomerChoose.Clear();
        }

        public void ReturnTheOrder()
        {
            vendor.Clothes.AddRange(ClothesCustomerChoose);
            ClothesCustomerChoose.Clear();
        }

        public void AddClothesCustomerChoose(int index)
        {
            if (vendor.Clothes.Any() == false)
                Console.WriteLine("Sorry! We are out of all the clothes in the store");

            var clothes = vendor.Clothes.ElementAtOrDefault(index - 1);
            if (clothes == null)
            {
                Console.WriteLine("Sorry! The clothes you choose already sold");
            }

            ClothesCustomerChoose.Add(clothes);
            vendor.Clothes.Remove(clothes);

            Console.WriteLine("You choose clothes :" + clothes.Show(true));
        }
        
        #endregion

        #region Show Clothes in your store
        public void ListClothing(bool isBuyer)
        {
            if (isBuyer)
                HelperForDisplay(vendor.Clothes, isBuyer);
            else
                HelperForDisplay(SupplierClothes, isBuyer);
        }

        private void HelperForDisplay(List<IClothing> list, bool isBuyer)
        {
            for (int index = 1; index <= list.Count(); index++)
            {
                list.ElementAt(index - 1).Display(index, isBuyer);
            }
        }
        #endregion

        #region Control the Flow Of Main Process (Base on customer answer)

        private bool HelperForStandarizeTheAnswer(string answer)
        {
            if (answer.Trim().ToLower() == "yes")
            {
                return true;
            }

            return false;
        }
        public bool IsAnsweringContinue(string answer)
        {
            return HelperForStandarizeTheAnswer(answer);
        }

        public bool IsAnsweringBuy(string answer)
        {
            return HelperForStandarizeTheAnswer(answer);
        }

        public bool IsAnsweringTheOrderCorrected(string answer)
        {
            return HelperForStandarizeTheAnswer(answer);
        }

        public bool IsAnsweringContinueUseApp(string answer)
        {
            return HelperForStandarizeTheAnswer(answer);
        }

        public void ControlTheFlowBuying(bool isContinueToBuy, bool isBuyer)
        {
            string answer = "";
            while (isContinueToBuy == true)
            {
                Console.WriteLine("Here is the list of clothes in my store. Please have look at this:");
                ListClothing(isBuyer);

                Console.WriteLine("What would you like to buy? Input the number you want to buy:");
                var index = Console.ReadLine();

                int indexChoose = 0;
                if (Int32.TryParse(index, out indexChoose) == false)
                {
                    Console.WriteLine("Sorry! Your input was not right! Can you choose again?");
                }
                else
                {
                    if (isBuyer)
                        AddClothesCustomerChoose(indexChoose);
                    else AddClothesFromTheSupplier(indexChoose);

                    Console.WriteLine("Do you want to buy more (yes/no)?");
                    answer = Console.ReadLine();
                    isContinueToBuy = IsAnsweringContinue(answer);
                }
            }
        }
        #endregion
    }
}
