using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProgram.UnitTests
{
    public class FakeShippingCalculator : IShippingCalculator
    {
        public float CalculatorShipping(Order order) => 5;

    }
}
