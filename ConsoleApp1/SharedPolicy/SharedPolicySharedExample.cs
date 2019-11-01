using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Text;
using ConsoleApp1;

namespace ConsoleApp1
{
    class SharedObject
    {
        public string Message { get; set; }
    }

    }
    class SharedPolicySharedExample
    {
        [Import("sharedExample", RequiredCreationPolicy = CreationPolicy.Shared)]
        private SharedObject obj1;

        [Import("sharedExample", RequiredCreationPolicy = CreationPolicy.Shared)]
        private SharedObject obj2;

        [Export("sharedExample")]
        private SharedObject exported = new SharedObject();

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);

            var example = new SharedPolicySharedExample();

            compositionContainer.ComposeParts(example);

            example.obj1.Message = "Obj1";
            example.obj2.Message = "Obj2";

            Console.WriteLine(example.obj1.Message);
            Console.WriteLine(example.obj2.Message);
        }
}
