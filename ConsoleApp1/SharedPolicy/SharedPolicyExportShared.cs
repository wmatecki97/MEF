using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    [Export, PartCreationPolicy(CreationPolicy.Shared)]
    //[Export, PartCreationPolicy(CreationPolicy.NonShared)]
    class ExportSharedObject
    {
        public string Message { get; set; }
    }

    class SharedPolicyExportShared
    {
        [Import]
        private ExportSharedObject obj1;

        [Import]
        private ExportSharedObject obj2;

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);

            var example = new SharedPolicyExportShared();

            compositionContainer.ComposeParts(example);

            example.obj1.Message = "Obj1";
            example.obj2.Message = "Obj2";

            Console.WriteLine(example.obj1.Message);
            Console.WriteLine(example.obj2.Message);
        }
    }
}
