using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    class AllowDefault
    {
        [Import(AllowDefault=true)] // should this prop take default value when there is a problem with export
        private string imported;

        //none of below texts would be printed because there are a lot of exported strings in this assembly
        [Export]
        private string exported = "This is exported text 1!";

        [Export]
        private string exported2 = "This is exported text 2!";

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly()); 
            var compositionContainer = new CompositionContainer(assemblyCatalog);

            var example = new AllowDefault();

            compositionContainer.ComposeParts(example); 

            Console.WriteLine(example.imported);
        }
    }
}
