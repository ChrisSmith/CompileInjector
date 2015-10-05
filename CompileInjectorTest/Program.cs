using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompileInjector;

namespace CompileInjectorTest
{
    public class Program
    {
        public void Main(string[] args)
        {
            var greeter = Greeter.Factory();
            Console.WriteLine(greeter.GetMessage());
            Console.ReadLine();
        }
    }
}
