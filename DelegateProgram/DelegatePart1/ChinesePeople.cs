using System;

namespace DelegateProgram.DelegatePart1
{
    public class ChinesePeople:IGreetService
    {
        public void ChineseGreeting(string name)
        {
            Console.WriteLine($"早上好,{name}");
        }

        public void Greeting(string name)
        {
            Console.WriteLine($"早上好,{name}");
        }
    }

    
}
