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

            Console.WriteLine(str.IsValidJson());
        }
    }

    public static class Utils
    {
        public static XDocument XDocument => XDocument.Parse(File.ReadAllText(@"E:\CSharp\Manganese\Manganese\bin\Debug\Manganese.xml"));

        private static IEnumerable<XElement?> MemberElements => XDocument.Descendants("member"); 

        public static XElement? Map(this Type type)
        {
            var re = MemberElements
                .Where(e => e?.Attribute("name")!.Value.StartsWith("T") is true)
                .First(e => e?
                    .Attribute("name")!.Value.SubstringAfter(":")
                    .Split(".").Last() == type.Name);

            return re;
        }

        public static XElement? Map(this MethodInfo method)
        {
            var candidates = MemberElements
                .Where(e => e?.Attribute("name")?.Value.StartsWith("M") is true)
                .Where(e => e?.Attribute("name")?.Value.Contains(method.Name) is true);

            var paramInfos = method.GetParameters();
                
            foreach (var candidate in candidates)
            {
                var paramNames = candidate?.Elements("param")
                    .Select(z => z.Attribute("name")?.Value);
                
                if (paramInfos.Select(x => x.Name)
                    .All(x => paramNames?.Contains(x) is true))
                {
                    return candidate;
                }
            }

            throw new ArgumentException($"Unexpected method: {method.Name} in {method.GetParameters().JoinToString(",")}");
        }

        public static XElement? Map(this ParameterInfo parameter, MethodInfo methodInfo)
        {
            var methodElement = methodInfo.Map();
            
            return methodElement?
                .Elements("param")
                .First(e => e.Attribute("name")?.Value == parameter.Name);
        }
        
        public static readonly IEnumerable<Type> Types = typeof(ArrayDetector).Assembly.GetTypes().Where(x => x.IsPublic && x.IsAbstract);

        public static object CW(this object origin, string prefix = "")
        {
            Console.WriteLine($"{prefix}{origin}");

            return origin;
        }
    }
}