using System.Diagnostics;
using Manganese.Array;
using Manganese.Text;

namespace Manganese.Test
{
    class Program
    {
        public static void Main()
        {
            var o = new object[]
            {
                new { a1 = "a1" },
                new { a2 = "a21" },
                new { a3 = "a13" },
                new { a4 = "a14", a5 = true },
            }.Output();

            Console.WriteLine(o.JoinToString(" ", o1 => o1.Serialize()));

            // var s = new List<int>()
            // {
            //     1, 2, 3, 4, 5, 6, 7
            // }.Remove(new[] { 8 });
            //
            // Console.WriteLine(s);
        }
    }
}