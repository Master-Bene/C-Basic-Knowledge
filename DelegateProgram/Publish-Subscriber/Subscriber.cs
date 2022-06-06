using System;
using System.Threading;

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

        public void OnInvoke()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));      // 模拟耗时三秒才能完成方法
            Console.WriteLine("wait for 3 seconds,Subscriber Invoked!");
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
            //throw new Exception("Subscriber2 异常了");
            throw new NotImplementedException("Subscriber2 异常了");
            Console.WriteLine($"Subscriber2 Invoked! number:{count}");
            return "Subscriber2";
        }
        public void OnInvoke()
        {
            throw new Exception("Subsciber2 Failed");   // 即使抛出异常也不会影响到客户端
            Console.WriteLine(" Subscriber2 Immediately Invoked!");
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
        public void OnInvoke()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));     // 模拟耗时两秒才能完成方法
            Console.WriteLine("wait for 2 seconds,Subscriber3 Invoked!");
        }
    }

}
