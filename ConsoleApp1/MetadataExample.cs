using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    public interface IMetadata //PUBLIC interface containing JUST ONE property that is named like dictionary key. That property must be compile time known
    {
        string text { get; }
        //string texts { get; } //Second property will make this interface useless
    }


    class MetadataExample
    {

        [ImportMany("metadataExample")]
        private List<Lazy<string, IMetadata>> imported;

        [Export("metadataExample")]
        [ExportMetadata("text", "Yes")] //METADATA IS A DICTIONARY STRING OBJECT
        private string exported = "This is exported text 1!";

        [Export("metadataExample")]
        [ExportMetadata("text", "No")]
        private string exported2 = "This is exported text 2!";

        public static void Run()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);

            var example = new MetadataExample();

            compositionContainer.ComposeParts(example);

            foreach (Lazy<string, IMetadata> text in example.imported)
            {
                if (text.Metadata.text == "Yes")
                    Console.WriteLine(text.Value.ToUpper());
                else
                    Console.WriteLine(text.Value);
            }
        }
    }
}
