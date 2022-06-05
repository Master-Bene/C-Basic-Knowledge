namespace InterfaceProgram
{
    public class ShippingCalculator : IShippingCalculator
    {
        public ShippingCalculator()
        {
            Console.WriteLine("普通价格已经被创建");
        }
        //TODO 方法程序块
        public int Calculator(Order order)
        {
            return order.Price > 50 ? 10 : 0;
        }
        //方法表达式

        public float CalculatorShipping(Order order) => order.Price > 50 ? 10 : 0;
    }
}
