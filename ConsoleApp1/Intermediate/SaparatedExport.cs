using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace ConsoleApp1
{
    internal class SeparatedExport
    {
        [Import]
        private int integer;

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly()); //CATALOG WITH EXPORTS
            var compositionContainer = new CompositionContainer(assemblyCatalog); // FIND EXPORTS IN CATALOG(S)

            var example = new SeparatedExport();

            compositionContainer.ComposeParts(example); //SATISFY OBJECTS IMPORTS WITH EXPORTS FROM THE CONTAINER

            Console.WriteLine(example.integer);
        }
    }
}