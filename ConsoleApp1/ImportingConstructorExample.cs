using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    [Export]
    class ClassWithImportingConstructor
    {
        public string Message { get; set; } = "I am T1 object";

        public ClassWithImportingConstructor()
        {
        }

        //This constructor overrides parameterless constructor
        [ImportingConstructor]
        public ClassWithImportingConstructor([Import("constructorParameter")]string message)
        {
            Message = message;
        }
    }

    class ImportingConstructorExample
    {
        [Export("constructorParameter")]
        public string exportedText => "Hello world!";

        [Import]
        private ClassWithImportingConstructor importedClassWithImportingConstructor;

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);

            var example =  new ImportingConstructorExample();

            compositionContainer.ComposeParts(example);

            Console.WriteLine(example.importedClassWithImportingConstructor.Message);
        }
    }
}
