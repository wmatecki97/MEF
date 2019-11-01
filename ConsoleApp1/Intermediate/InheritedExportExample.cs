using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    [InheritedExport]
    public interface IInheritedExportExample
    {
        string message { get; }
    }

    public class A : IInheritedExportExample
    {
        public string message => "Class A!";
    }

    public class B : IInheritedExportExample
    {
        public string message => "Class B!";
    }

    class InheritedExportExample
    {
        [ImportMany(typeof(IInheritedExportExample))]
        private List<Lazy<IInheritedExportExample>> imported;

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);

            var example = new InheritedExportExample();

            compositionContainer.ComposeParts(example);

            foreach (var classLazy in example.imported)
            {
                Console.WriteLine(classLazy.Value.message);
            }
        }
    }
}
