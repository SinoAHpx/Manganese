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
                type.Map()?.Attribute("name")?.Value.CW();
                var methods = type.GetMethods().Where(x => x.IsStatic && x.IsPublic);
                
                foreach (var method in methods)
                {
                    method.Map()?.Attribute("name")?.Value.CW();
                }
            }
            
            /*
            // return;
            //
            // foreach (var docMember in xDocument.Descendants("member"))
            // {
            //     var name = docMember.Attribute("name")!.Value;
            //
            //     if (name.StartsWith("T"))
            //     {
            //         name = name.Empty("T:");
            //
            //         var markdownLine = new StringBuilder($"### [{name.SubstringAfter(".", true)}]");
            //         markdownLine.Append($"(https://github.com/SinoAHpx/Manganese/tree/master/");
            //         markdownLine.Append($"{name.Split(".").JoinToString("/")}.cs)");
            //         mdLines.Add(markdownLine.ToString());
            //
            //         var element = docMember.Element("summary");
            //
            //         mdLines.Add(docMember.Element("summary")!.Value
            //             .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
            //             .Where(x => !x.IsNullOrEmpty())
            //             .Select(x => x.Trim())
            //             .JoinToString(Environment.NewLine));
            //     }
            //     else
            //     {
            //         var path = name.Contains("``")
            //             ? name.SubstringBetween(":", "``").Split(".")
            //             : name.SubstringBetween(":", "(").Split(".");
            //         var methodName = path.Last();
            //         var typeName = path[^2];
            //
            //         var methodInfo = Utils.GetMethodByName(methodName, Utils.GetTypeByName(typeName));
            //
            //         var listHead = new StringBuilder($"+ `{methodName}({methodInfo.ReturnType.Name})`: ");
            //         listHead.Append(docMember.Element("summary")!.Value);
            //
            //         mdLines.Add(listHead.ToString());
            //
            //         var param = docMember.Elements("param");
            //         if (!param.Any())
            //             continue;
            //         
            //         foreach (var paramElement in docMember.Elements("param"))
            //         {
            //             var paramName = paramElement.Attribute("name")!.Value;
            //             var listItem = new StringBuilder($"\r+ `{paramName}");
            //             listItem.Append($"({Utils.GetParamByName(paramName, methodInfo).ParameterType.Name})");
            //             listItem.Append('`');
            //             if (!paramElement.Value.IsNullOrEmpty())
            //                 listItem.Append($": {paramElement.Value}");
            //
            //             mdLines.Add(listItem.ToString());
            //         }
            //     }
            // }
            //
            // foreach (var s in mdLines)
            // {
            //     Console.WriteLine(s);
            // }
            */
        }
    }

    public static class Utils
    {
        public static XDocument XDocument => XDocument.Parse(File.ReadAllText(@"E:\CSharp\Manganese\Manganese\bin\Debug\Manganese.xml"));

        private static IEnumerable<XElement?> MemberElements => XDocument.Descendants("member"); 

        public static XElement? Map(this Type type)
        {
            var re = MemberElements
                .Where(e => e.Attribute("name")!.Value.StartsWith("T"))
                .First(e => e
                    .Attribute("name")!.Value.SubstringAfter(":")
                    .Split(".").Last() == type.Name);

            return re;
        }

        public static XElement? Map(this MethodInfo method)
        {
            var candidates = MemberElements
                .Where(e => e.Attribute("name")!.Value.StartsWith("M"))
                .Where(e => e.Attribute("name")!.Value.Contains(method.Name));

            var paramInfos = method.GetParameters();
                
            foreach (var candidate in candidates)
            {
                var paramNames = candidate.Elements("param")
                    .Select(z => z.Attribute("name")?.Value);
                
                if (paramInfos.Select(x => x.Name)
                    .All(x => paramNames.Contains(x)))
                {
                    return candidate;
                }
            }

            new ArgumentException($"Unexpected method: {method.Name} in {method.GetParameters().JoinToString(",")}")
                .Message.CW();

            return null;
        }
        
        
        
        public static readonly IEnumerable<Type> Types = typeof(ArrayDetector).Assembly.GetTypes().Where(x => x.IsPublic && x.IsAbstract);

        public static Type GetTypeByName(string name)
        {
            return Types.First(x => x.Name == name);
        }

        public static MethodInfo GetMethodByName(string name, Type type)
        {
            return type.GetMethods().First(x => x.Name == name);
        }

        public static ParameterInfo GetParamByName(string name, MethodInfo methodInfo)
        {
            if (methodInfo.Name == "Output")
            {
                var a = methodInfo.GetParameters();
                Console.WriteLine(a);
            }
            return methodInfo.GetParameters().First(x => x.Name == name);
        }
        
        public static object CW(this object origin, string prefix = "")
        {
            Console.WriteLine($"{prefix}{origin}");

            return origin;
        }
    }
}