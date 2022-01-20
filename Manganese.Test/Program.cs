using System.Diagnostics;
using Manganese.Array;
using Manganese.Text;

namespace Manganese.Test
{
    class Program
    {
        public static void Main()
        {
            var o = new[] { "a1", "a2", "a3", "a44", "a55" }.Output();

            while (true)
            {
                Console.Write("Input: ");
                var input = Console.ReadLine();
                if (input.IsIn(o))
                {
                    Console.WriteLine("Contains!");
                }
            }

            // var s = new List<int>()
            // {
            //     1, 2, 3, 4, 5, 6, 7
            // }.Remove(new[] { 8 });
            //
            // Console.WriteLine(s);
        }
    }
}