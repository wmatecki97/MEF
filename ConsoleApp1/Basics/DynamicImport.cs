using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace ConsoleApp1.Basics
{
    class DynamicExampleClass
    {
    }
    class DynamicImport
    {
        [Export("dynamic", typeof(DynamicExampleClass))]
        private DynamicExampleClass Export1 => new DynamicExampleClass();

        [Import("dynamic")]
        private dynamic dynamicVariable; 

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);

            var example = new DynamicImport();
            compositionContainer.ComposeParts(example);

            Console.WriteLine(example.dynamicVariable);
        }
    }
}
