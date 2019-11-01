using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Text;

namespace ConsoleApp1
{
    class AggregateCatalogExample
    {
        [Import("dir")]
        private int integer;

        [Import("dir2")]
        private int integer2;

        [Export("dir2")]
        private int exportedInteger = 20;

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(typeof(Program).Assembly);
            var directoryCatalog = new DirectoryCatalog("."); 
            
            var aggregateCatalog = new AggregateCatalog();//COLLECTION OF CATALOGS
            aggregateCatalog.Catalogs.Add(assemblyCatalog);
            aggregateCatalog.Catalogs.Add(directoryCatalog);

            var compositionContainer = new CompositionContainer(aggregateCatalog);
            var example = new AggregateCatalogExample();

            compositionContainer.ComposeParts(example);

            Console.WriteLine(example.integer);
            Console.WriteLine(example.integer2);
        }
    }
}
