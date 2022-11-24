using library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace lab07
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly theAssembly = Assembly.Load(new AssemblyName("animals"));//загружаем
            void AppendXML(string output)//запись в файл
            {
                File.AppendAllText("AssemblyInfo.xml", output + "\n");
            }
            File.Delete("AssemblyInfo.xml");
            AppendXML("<animals>");
            AppendXML(theAssembly.FullName);

            foreach(Type deftype in theAssembly.ExportedTypes)
            {
                if (deftype.GetTypeInfo().IsClass)
                {
                    // инца о классе
                    AppendXML($"\n<class> {deftype.Name} : {deftype.BaseType}");
                    // получаем его коммнты
                    IEnumerable<MyCommentAttribute> attributes = deftype.GetTypeInfo().GetCustomAttributes().OfType<MyCommentAttribute>().ToArray();
                    // если они есть то пишем коммент
                    if (attributes.Count() > 0)
                    {
                        foreach (MyCommentAttribute attribute in attributes)
                        {
                            AppendXML($"<comment>{attribute.Comment}</comment>");
                        }
                    }
                    // выводим инфу о методах
                    foreach (MethodInfo method in deftype.GetMethods())
                    {
                        AppendXML($"<method>{(method.IsStatic ? "static " : "")}{(method.IsVirtual ? "virtual " : "")}{method.ReturnType.Name} {method.Name} ()</method>");
                    }
                    AppendXML("</class>");
                }

            }
            AppendXML("</animals>");
        }
    }
}
