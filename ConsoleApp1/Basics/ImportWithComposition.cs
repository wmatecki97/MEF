using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace ConsoleApp1
{
    internal class ImportWithComposition
    {
        [Import]
        private string imported;

        [Export]
        private string exported = "This is exported text!";

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly()); //CATALOG WITH EXPORTS
            var compositionContainer = new CompositionContainer(assemblyCatalog); // FIND EXPORTS IN CATALOG(S)
            compositionContainer.ComposeParts();

            var example = new ImportWithComposition();

            Console.WriteLine(example.imported);
        }
    }
}