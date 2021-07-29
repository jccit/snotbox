using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace SnotboxRunner
{
    class Compiler
    {
        private static List<string> coreDlls = new List<string>()
        {
            "mscorlib.dll",
            "System.Runtime.dll",
            "System.Private.Corelib.dll",
            "netstandard.dll",
            "System.Text.RegularExpressions.dll",
            "System.Linq.dll",
            "System.Net.dll",
            "System.Data.dll",
            "System.Collections.dll",
            "System.IO.dll",
            "System.Console.dll",
        };

        public static Assembly Compile(string[] sourceFiles)
        {
            SyntaxTree[] syntaxTrees = new SyntaxTree[sourceFiles.Length];
            for (int i = 0; i < sourceFiles.Length; i++)
            {
                syntaxTrees[i] = CSharpSyntaxTree.ParseText(File.ReadAllText(sourceFiles[i]), null, sourceFiles[i], Encoding.UTF8).WithFilePath(sourceFiles[i]);
            }

            IEnumerable<MetadataReference> references = new[]{
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(Path.Combine(Environment.CurrentDirectory, "Snotbox/bin/Debug/net5.0/Snotbox.dll")),
            };

            foreach (var dll in coreDlls)
            {
                references = references.Concat(new[]
                {
                    MetadataReference.CreateFromFile(GetTrustedAssemblyPath(dll)),
                });
            }

            CSharpCompilation compilation = CSharpCompilation.Create(
                "addon",
                syntaxTrees,
                references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            var dllStream = new MemoryStream();
            var pdbStream = new MemoryStream();

            var result = compilation.Emit(dllStream, pdbStream);
            if (!result.Success)
            {
                Console.WriteLine("Error compiling addon");

                IEnumerable<Diagnostic> failures = result.Diagnostics.Where(
                    diagnostic => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error);

                foreach (Diagnostic diagnostic in failures)
                {
                    Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
                }

                return null;
            }

            dllStream.Seek(0, SeekOrigin.Begin);
            return Assembly.Load(dllStream.ToArray());
        }

        public static string GetTrustedAssemblyPath(string shortDllName)
        {
            string dllString = AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES").ToString();
            var dlls = dllString.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return dlls.First(d => d.Contains(shortDllName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
