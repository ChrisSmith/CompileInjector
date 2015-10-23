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

            //Console.WriteLine("ProcessId: " + Process.GetCurrentProcess().Id);
            //Console.ReadLine();

            var simpleInjectorContainer = new SimpleInjector.Container();
            var autofacBuilder = new ContainerBuilder();

            foreach (var type in typeof(Greeter).Assembly.GetTypes())
            {
                autofacBuilder.RegisterType(type);
                simpleInjectorContainer.Register(type);
            }

            //builder.Register<ClassWithDeps>((c) => ClassWithDeps.Factory());

            simpleInjectorContainer.Verify();

            var container = autofacBuilder.Build();

            TimeIt(() => simpleInjectorContainer.GetInstance<ClassWithDeps>(), "SimpleInjector");

            TimeIt(() => ClassWithDeps.Factory(), "Roslyn");

            TimeIt(() => ClassWithDeps.MakeClassWithDeps(), "MakeClassWithDeps");
            
            TimeIt(() => container.Resolve<ClassWithDeps>(), "Autofac");
            
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
