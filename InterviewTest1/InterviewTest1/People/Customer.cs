using InterviewTest1.Clothing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest1.People
{
    public sealed class Customer : BasePeople, IPeople
    {
        private List<IClothing> clothes = new List<IClothing>();
        public decimal BuyTShirtAtPrice
            => clothes.Find(x => x.GetType() == TypeClothing.TShirt).Buy();

        public decimal BuyDressShirtAtPrice
            => clothes.Find(x => x.GetType() == TypeClothing.DressShirt).Buy();

        public Customer()
        {
            var tshirt = new TShirt(
                size: "", // don't care for size && color at the moment
                color: "",
                sellerPrice: 0,
                buyerPrice: ConfigPrice.SellPriceForTShirt); // Customer: Buy at the price vendor sell
            clothes.Add(tshirt);

            var dressShirt = new DressShirt(
                size: "",
                color: "",
                sellerPrice: 0,
                buyerPrice: ConfigPrice.SellPriceForDressShirt); // Customer: Buy at the price vendor sell

            clothes.Add(dressShirt);
        }
    }
}
