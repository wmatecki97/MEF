using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Text;
using Exports;

namespace ConsoleApp1
{
    class DirectoryCatalogExample
    {
        [Import("dir")]
        private int integer;

        public static void Run()
        {
            //var directoryCatalog = new DirectoryCatalog("F:\\Programowanie\\C#\\MEF\\ImportExportExample\\Exports"); will not work
            var directoryCatalog = new DirectoryCatalog("F:\\Programowanie\\C#\\MEF\\ImportExportExample\\Exports\\bin\\Debug\\netcoreapp2.2"); // have to point to the catalog that contains dll
            //ANY TYPE OF PATHS CAN BE USED

            var compositionContainer = new CompositionContainer(directoryCatalog);
            var example = new DirectoryCatalogExample();

            compositionContainer.ComposeParts(example);

            Console.WriteLine(example.integer);
        }
    }
}
