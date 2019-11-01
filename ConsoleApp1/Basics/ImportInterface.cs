using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace ConsoleApp1
{
    interface IExmple
    {
        string text { get; }
    }

    [Export(typeof(IExmple))]
    class ExampleClass : IExmple
    {
        public string text => "Interface text!";
    }

    class ImportInterface 
    {

        [Import(typeof(IExmple))]
        IExmple exampleObject;

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);

            var example = new ImportInterface();

            compositionContainer.ComposeParts(example); //THIS METHOD CREATE INSTANCES OF ALL EXPORTED CLASSES

            Console.WriteLine(example.exampleObject.text);
        }
    }
}
