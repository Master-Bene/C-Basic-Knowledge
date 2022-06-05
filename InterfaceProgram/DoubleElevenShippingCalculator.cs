using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProgram
{
    public class DoubleElevenShippingCalculator : IShippingCalculator
    {
        public DoubleElevenShippingCalculator()
        {
            Console.WriteLine("双11价格已经被创建");
        }
        public float CalculatorShipping(Order order) => 0;

    }
}
