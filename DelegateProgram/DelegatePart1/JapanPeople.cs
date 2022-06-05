using System;

namespace DelegateProgram.DelegatePart1
{
    public class JapanPeople:IGreetService
    {
        public void Greeting(string name)
        {
            Console.WriteLine($"おはよう,{name}");
        }

        public void JapaneseGreeting(string name)
        {
            Console.WriteLine($"おはよう,{name}");
        }
    }
}
