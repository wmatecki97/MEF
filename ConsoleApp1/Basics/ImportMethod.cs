using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace ConsoleApp1.Basics
{
    internal class ImportMethod
    {
        [Export]
        private int ExportedSum(int x, int y) => x + y;

        //[Import]
        //int Sum(int x, int y);

        #region solution

        [Import]
        private Func<int, int, int> Sum; //treated as a delegate

        #endregion solution

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);
            var example = new ImportMethod();
            compositionContainer.ComposeParts(example);

            Console.WriteLine(example.Sum(1, 2));//should be 3
        }
    }
}