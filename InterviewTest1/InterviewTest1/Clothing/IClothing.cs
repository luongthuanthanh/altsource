using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest1.Clothing
{
    public interface IClothing
    {
        TypeClothing GetType();
        decimal Buy();

        decimal Sell();
        void Display(int index, bool isBuyer);
        string Show(bool isBuyer);
    }

    public class BaseClothing : IClothing
    {
        public TypeClothing Type { get; private set; }
        public string Size { get; private set; }

        public string Color { get; private set; }

        public decimal SellerPrice { get; private set; }

        public decimal BuyerPrice { get; private set; }

        public BaseClothing(string size, string color, decimal sellerPrice, decimal buyerPrice, TypeClothing type)
        {
            this.Size = size;
            this.Color = color;
            this.SellerPrice = sellerPrice;
            this.BuyerPrice = buyerPrice;
            this.Type = type;
        }

        public decimal Buy()
        {
            return this.BuyerPrice;
        }

        public decimal Sell()
        {
            return this.SellerPrice;
        }

        public TypeClothing GetType()
        {
            return this.Type;
        }

        public void Display(int index, bool isBuyer)
        {
            if (isBuyer)
            {
                Console.WriteLine($"{index}. {this.Type.ToString()} (size({this.Size}), Color({this.Color}): {this.SellerPrice}");
                return;
            }

            Console.WriteLine($"{index}. {this.Type.ToString()} (size({this.Size}), Color({this.Color}): {this.BuyerPrice}");
        }

        public string Show(bool isBuyer)
        {
            if (isBuyer)
            {
                return $"{this.Type.ToString()} (size({this.Size}), Color({this.Color}): {this.SellerPrice}";
            }

            return $"{this.Type.ToString()} (size({this.Size}), Color({this.Color}): {this.BuyerPrice}";
        }
    }

    public enum TypeClothing
    {
        TShirt = 0,
        DressShirt = 1
    }
}
