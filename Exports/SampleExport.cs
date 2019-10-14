using System.ComponentModel.Composition;

namespace Exports
{
    public class SampleExport
    {
        [Export]
        public int ExportedInteger => 100;
    }
}
