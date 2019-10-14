using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace ConsoleApp1
{
    class MultipleExports
    {
        [Import("Identifier")] // looking for exported string with CONTRACTNAME = "Identifier". When there isn't any exported string with this identifier throws exception.
        private string imported;

        [Export]
        private string exported = "This is exported text 1!";

        [Export("Identifier")]
        private string exported2 = "This is exported text 2!";

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);

            var example = new MultipleExports();

            compositionContainer.ComposeParts(example);

            Console.WriteLine(example.imported);
        }
    }
}
