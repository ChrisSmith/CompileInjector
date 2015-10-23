using System;
using CompileInjector;
using System.Diagnostics;
using Autofac;
using System.Runtime;

namespace CompileInjectorTest
{
    public class Program
    {
        public void Main(string[] args)
        {
            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
            
            var simpleInjectorContainer = new SimpleInjector.Container();
            var autofacBuilder = new ContainerBuilder();

            foreach (var type in typeof(Greeter).Assembly.GetTypes())
            {
                autofacBuilder.RegisterType(type);
                simpleInjectorContainer.Register(type);
            }
            
            simpleInjectorContainer.Verify();

            var container = autofacBuilder.Build();

            Console.WriteLine("Starting sample performance test");

            TimeIt(() => ClassWithDeps.InlinedConstructor(), "Inlined .NET (base line)");

            TimeIt(() => ClassWithDeps.Factory(), "Compile Injector (this library)");

            TimeIt(() => container.Resolve<ClassWithDeps>(), "Autofac");

            TimeIt(() => simpleInjectorContainer.GetInstance<ClassWithDeps>(), "SimpleInjector");
            
            Console.WriteLine("Done");
        }

        private static void TimeIt(Action action, string name)
        {
            action(); // warmup
            GC.Collect();

            var sw = Stopwatch.StartNew();
            for(int i = 0; i < 5000; i++)
            {
                action();
            }
            sw.Stop();
            
            Console.WriteLine(string.Format("{0}: {1}ms", name, sw.ElapsedMilliseconds));
        }
    }
}
