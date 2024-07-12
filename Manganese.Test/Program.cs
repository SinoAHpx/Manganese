using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Manganese.Array;
using Manganese.Number;
using Manganese.Process;
using Manganese.Text;
using Newtonsoft.Json;

namespace Manganese.Test
{
    class Program
    {
        public static async Task Main()
        {
            Console.WriteLine($"Memory size is: {ProcessAtom.GetComputerMemorySize().MegabytesToGigabytes()}MB");
        }
    }

}