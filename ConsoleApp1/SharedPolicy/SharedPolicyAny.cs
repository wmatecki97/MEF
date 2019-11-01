using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    [Export, PartCreationPolicy(CreationPolicy.Any)]
    //[Export, PartCreationPolicy(CreationPolicy.NonShared)]
    class ExportAnyObject
    {
        public string Message { get; set; }
    }

    class SharedPolicyAny
    {
        [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
        //[Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        private ExportAnyObject obj1;

        [Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        private ExportAnyObject obj2;

        //[Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
        //[Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        [Import]
        private ExportAnyObject obj3;

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);

            var example = new SharedPolicyAny();

            compositionContainer.ComposeParts(example);

            example.obj1.Message = "Obj1";
            example.obj2.Message = "Obj2";
            example.obj3.Message = "Obj3";

            Console.WriteLine(example.obj1.Message);
            Console.WriteLine(example.obj2.Message);
            //Console.WriteLine(example.obj3.Message);
        }
    }

}
