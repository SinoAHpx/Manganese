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
        public static void Main()
        {
            var mdLines = new List<string>();
            
            foreach (var type in Utils.Types)
            {
                //type header
                var typeHeader = new StringBuilder($"### [{type.Name}]");
                typeHeader.Append($"(https://github.com/SinoAHpx/Manganese/tree/master/");
                typeHeader.Append($"{type.Namespace?.Split(".").JoinToString("/")}/{type.Name}.cs)");

                mdLines.Add(typeHeader.ToString());
                
                //type summary
                var typeElement = type.Map();
                var typeSummaryElement = typeElement?.Element("summary");
                var typeSummary = typeSummaryElement!.Value.Trim()
                    .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                    .Where(x => !x.IsNullOrEmpty())
                    .Select(x => x.Trim())
                    .JoinToString(Environment.NewLine);
                
                mdLines.Add(typeSummary);
                
                var methods = type.GetMethods().Where(x => x.IsStatic && x.IsPublic);
                
                foreach (var method in methods)
                {
                    //method header

                    var methodElement = method.Map();
                    
                    var methodHeader = new StringBuilder($"+ `{method.Name}({method.ReturnType.Name})`: ");
                    methodHeader.Append(methodElement?.Element("summary")?.Value.Trim());
                    mdLines.Add(methodHeader.ToString());
                    
                    //parameters
                    foreach (var parameter in method.GetParameters())
                    {
                        var parameterElement = parameter.Map(method);
                        var parameterHeader =
                            new StringBuilder($"\t+ `{parameter.Name}({parameter.ParameterType.Name})`");

                        if (!parameterElement.Value.IsNullOrEmpty())
                            parameterHeader.Append($": {parameterElement.Value.Trim()}");

                        mdLines.Add(parameterHeader.ToString());
                    }
                }
            }

            File.WriteAllLines(@"C:\Users\ahpx\Desktop\test.xml", mdLines);
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