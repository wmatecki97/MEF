using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    [InheritedExport]
    public interface IDiscoverableExample
    {
        string message { get; }
    }

    public class D1 : IDiscoverableExample
    {
        public string message => "Class A!";
    }

    [PartNotDiscoverable]
    public class D2 : IDiscoverableExample
    {
        public string message => "Class B!";
    }

    class NotDiscoverableExample
    {
        [ImportMany(typeof(IDiscoverableExample))]
        private List<Lazy<IDiscoverableExample>> imported;

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);

            var example = new NotDiscoverableExample();

            compositionContainer.ComposeParts(example);

            foreach (var classLazy in example.imported)
            {
                Console.WriteLine(classLazy.Value.message);
            }
        }
    }
}
