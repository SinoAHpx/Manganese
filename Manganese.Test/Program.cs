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
            var o = new
            {
                a1 = "Awd",
                a = new
                {
                    b = new
                    {
                        c = 1
                    }
                }
            };

            var s = o.Serialize();
            Console.WriteLine(s);

            var o2 = s.Deserialize<O2>();
            Console.WriteLine(s.Fetch("a.b.c"));
            Console.WriteLine(o2.C);
            Console.WriteLine(o2.A);

            // var s = new List<int>()
            // {
            //     1, 2, 3, 4, 5, 6, 7
            // }.Remove(new[] { 8 });
            //
            // Console.WriteLine(s);
        }
    }

    [JsonConverter(typeof(JsonPathConverter))]
    class O2
    {
        [JsonProperty("a1")]
        public string A {get; set;}
        
        [JsonProperty("a.b.c")]
        public string C { get; set; }
    }
}