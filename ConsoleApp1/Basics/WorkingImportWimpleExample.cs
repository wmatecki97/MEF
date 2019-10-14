using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace ConsoleApp1
{
    internal class WorkingImportWimpleExample
    {
        [Import]
        private string imported;

        [Export]
        private string exported = "This is exported text!";

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly()); //CATALOG WITH EXPORTS
            var compositionContainer = new CompositionContainer(assemblyCatalog); // FIND EXPORTS IN CATALOG(S)

            var example = new WorkingImportWimpleExample();

            compositionContainer.ComposeParts(example); //SATISFY OBJECTS IMPORTS WITH EXPORTS FROM THE CONTAINER

            Console.WriteLine(example.imported);
        }
    }
}