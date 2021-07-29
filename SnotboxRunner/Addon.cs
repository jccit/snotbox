using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace SnotboxRunner
{
    public class Addon
    {
        private Assembly asm;

        public Addon(string addonDir)
        {
            var codePath = Path.Combine(addonDir, "code");
            var sourceFiles = Directory.GetFiles(codePath, "*.cs", SearchOption.AllDirectories);

            asm = Compiler.Compile(sourceFiles);
        }

        public Type[] GetTypes()
        {
            return asm.GetTypes();
        }

        public void PrintTypes()
        {
            foreach (var type in GetTypes())
            {
                Console.WriteLine(type.Name + " : " + type.BaseType);
            }
        }

        public Type GetGameClassType()
        {
            foreach (var type in GetTypes())
            {
                if (type.BaseType.ToString() == "Sandbox.Game") {
                    return type;
                }
            }

            return null;
        }

        public object CreateInstance(Type type)
        {
            var instance = Activator.CreateInstance(type);
            return instance;
        }
    }
}