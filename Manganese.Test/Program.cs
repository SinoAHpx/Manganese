using System.Diagnostics;
using Manganese.Array;
using Manganese.Text;

namespace Manganese.Test
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine(@"C:".CombinePath(new[] { "test", @"awdawd\awd\a.exe" }));

            // var s = new List<int>()
            // {
            //     1, 2, 3, 4, 5, 6, 7
            // }.Remove(new[] { 8 });
            //
            // Console.WriteLine(s);
        }
    }
}