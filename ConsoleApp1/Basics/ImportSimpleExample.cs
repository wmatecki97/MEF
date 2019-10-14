using System;
using System.ComponentModel.Composition;

namespace ConsoleApp1
{
    internal class ImportSimpleExample
    {
        [Import]
        private string imported;

        [Export]
        private string exported = "This is exported text!";

        public static void Run()
        {
            var example = new ImportSimpleExample();
            Console.WriteLine(example.imported);
        }
    }
}