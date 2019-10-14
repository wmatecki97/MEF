using System;

namespace ConsoleApp1
{
    internal class SimpleExample
    {
        private string text;

        public static void Run()
        {
            var p = new SimpleExample();
            p.text = "This is example text";
            Console.WriteLine(p.text);
        }
    }
}