using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateProgram.DelegatePart1
{
    public class FrancePeople :IGreetService
    {
        public void FranchGreeting(string name)
        {
            Console.WriteLine($"Bonjour,{name}");
        }

        public void Greeting(string name)
        {
            Console.WriteLine($"Bonjour,{name}");
        }
    }
}
