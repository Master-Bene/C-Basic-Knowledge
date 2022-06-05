using System;

namespace DelegateProgram.Publish_Subscriber
{
    public class Subscriber
    {
        public void OnNumberChange(int count) => Console.WriteLine($"Subscriber notified :count={count}");
        public string OnNumberChange()
        {
            Console.WriteLine("Subscriber Invoked!");
            return "Subscriber";
        }
        public string OnNumberChange1(int count)
        {
            Console.WriteLine($"Subscriber Invoked! number:{count}");
            return "Subscriber";
        }
    }
    public class Subscriber2
    {
        public void OnNumberChange(int count) => Console.WriteLine($"Subscriber2 notified :count={count}");
        public string OnNumberChange()
        {
            Console.WriteLine("Subscriber2 Invoked!");
            return "Subscriber2";
        }
        public string OnNumberChange1(int count)
        {
            throw new Exception("Subscriber2 异常了");
            Console.WriteLine($"Subscriber2 Invoked! number:{count}");
            return "Subscriber2";
        }
    }

    public class Subscriber3
    {
        public void OnNumberChange(int count) => Console.WriteLine($"Subscriber3 notified :count={count}");
        public string OnNumberChange()
        {
            Console.WriteLine("Subscriber3 Invoked!");
            return "Subscriber3";
        }
        public string OnNumberChange1(int count)
        {
            Console.WriteLine($"Subscriber3 Invoked! number:{count}");
            return "Subscriber3";
        }
    }

}
