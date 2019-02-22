using InterviewTest1.Clothing;
using InterviewTest1.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest1
{
    public class Vendor
    {
        // Quantity Of Clothing In Store 
        public List<IClothing> Clothes = new List<IClothing>();

        public Vendor(List<IClothing> clothes)
        {
            this.Clothes = clothes;
        }
        
    }
}
