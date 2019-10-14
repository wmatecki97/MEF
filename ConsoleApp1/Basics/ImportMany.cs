using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    class ImportMany
    {
        [ImportMany] //imports collection of exported strings
        private List<string> imported;

        [Export]
        private string exported = "This is exported text 1!";

        [Export]
        private string exported2 = "This is exported text 2!";

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);

            var example = new ImportMany();

            compositionContainer.ComposeParts(example);

            Console.WriteLine(String.Join('\n', example.imported));
        }
    }
}
