using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest1.Clothing
{
    public class DressShirt : BaseClothing, IClothing
    {

        public DressShirt(string size, string color, decimal sellerPrice, decimal buyerPrice) : base(size, color, sellerPrice, buyerPrice, TypeClothing.DressShirt)
        {
        }
    }
}
