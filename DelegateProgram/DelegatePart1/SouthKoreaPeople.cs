using System;
using System.IO;
using System.Text;

namespace DelegateProgram.DelegatePart1
{
    public class SouthKoreaPeople : IGreetService
    {
        public void Greeting(string name)
        {
            Console.WriteLine($"좋은 아침，{name}");
        }

        public void KoreanGreeting(string name)
        {
            Console.WriteLine($"좋은 아침，{name}");
        }
    }
}
