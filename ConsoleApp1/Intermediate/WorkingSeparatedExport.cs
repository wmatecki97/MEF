using Exports;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    class WorkingSeparatedExport
    {
        [Import]
        private int integer;

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(typeof(SampleExport).Assembly); //OTHER PROJECT ASSEMBLY
            var compositionContainer = new CompositionContainer(assemblyCatalog); 
            var example = new WorkingSeparatedExport();

            compositionContainer.ComposeParts(example); 

            Console.WriteLine(example.integer);
        }
    }
}
