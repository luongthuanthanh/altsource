using InterviewTest1.Clothing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest1.People
{
    public sealed class Supplier : BasePeople, IPeople
    {
        private List<IClothing> clothes = new List<IClothing>();
        public decimal SellTShirtAtPrice
            => clothes.Find(x => x.GetType() == TypeClothing.TShirt).Sell();

        public decimal SellDressShirtAtPrice
            => clothes.Find(x => x.GetType() == TypeClothing.DressShirt).Sell();

        public Supplier()
        {
            var tshirt = new TShirt(
                size: "", // don't care for size && color at the moment
                color: "",
                sellerPrice: ConfigPrice.BuyPriceForTShirt,
                buyerPrice: 0); // Supplier: Sell at the price at the buy
            clothes.Add(tshirt);

            var dressShirt = new DressShirt(
                size: "",
                color: "",
                sellerPrice: ConfigPrice.BuyPriceForDressShirt,
                buyerPrice: 0); // Supplier: Sell at the price at the buy

            clothes.Add(dressShirt);
        }
    }

}
