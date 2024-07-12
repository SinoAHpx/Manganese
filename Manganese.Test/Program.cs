using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Manganese.Array;
using Manganese.Text;
using Newtonsoft.Json;

namespace Manganese.Test
{
    class Program
    {
        public static async Task Main()
        {
            var client = new HttpClient();
            var str = await client.GetStringAsync("http://httpbin.org/get");

            Console.WriteLine(str.i);
        }
    }

}