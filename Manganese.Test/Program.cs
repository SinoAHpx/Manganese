using System.Diagnostics;
using Manganese.Array;
using Manganese.Text;
using Newtonsoft.Json;

namespace Manganese.Test
{
    class Program
    {
        public static void Main()
        {
            var a = new List<string>
            {
                "awd",
                "awd1",
                "awd2",
                "awd3"
            };

            Console.WriteLine(a.Any("awd"));
            Console.WriteLine(a.Any("awd1"));
            Console.WriteLine(a.Any("awd4"));
        }
    }
}