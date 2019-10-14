using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    class LazyImporting
    {
        [ImportMany] //imports collection of exported strings
        private List<Lazy<string>> imported;

        [Export]
        private string exported = "This is exported text 1!";

        [Export]
        private string exported2 = "This is exported text 2!";

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);

            var example = new LazyImporting();

            compositionContainer.ComposeParts(example);

            foreach (Lazy<string> text in example.imported)
            {
                Console.WriteLine(text.Value);//Now the export is matched, but we have to call ".Value"
            }

        }
    }
}
