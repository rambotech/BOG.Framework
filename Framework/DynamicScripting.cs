using System;
using System.CodeDom.Compiler;

namespace BOG.Framework
{
    /// <summary>
    /// This class is a wrapper for the System.CodeDom.Compiler namespace.  
    /// </summary>
    public static class DynamicScripting
    {
        /// <summary>
        /// Language of the code to be compiled.
        /// </summary>
        public enum Languages
        {
            VB,
            CSharp
        }

        /// <summary>
        /// Compile a script, using the source and reference assemblies specified.  The return value will have the executable object
        /// and any errors encountered.
        /// </summary>
        /// <param name="Source">The source to compile as a string.</param>
        /// <param name="Reference">array of strings, each representing an assebmly or namespace to include.</param>
        /// <param name="Language">The Languages enumeration value for the code language.</param>
        /// <param name="DebugInformation">Whether to include debug information in the compiled object.</param>
        /// <returns></returns>
        public static CompilerResults CompileScript(string Source, string[] Reference, Languages Language, bool DebugInformation)
        {
            CodeDomProvider provider = null;
            CompilerResults results;

            switch (Language)
            {
                case Languages.VB:
                    provider = new Microsoft.VisualBasic.VBCodeProvider();
                    break;
                case Languages.CSharp:
                    provider = new Microsoft.CSharp.CSharpCodeProvider();
                    break;
            }

            // Configure parameters
            CompilerParameters parms = new CompilerParameters();
            parms.GenerateExecutable = false;
            parms.GenerateInMemory = true;
            parms.IncludeDebugInformation = DebugInformation;
            if (Reference != null)
                foreach (string r in Reference)
                    parms.ReferencedAssemblies.Add(r);

            // Compile
            results = provider.CompileAssemblyFromSource(parms, Source);

            return results;
        }

        /// <summary>
        /// Locate an interface in an assembly, which is needed to execute the assembly.
        /// </summary>
        /// <param name="DLL"></param>
        /// <param name="InterfaceName"></param>
        /// <returns></returns>
        public static object FindInterface(System.Reflection.Assembly DLL, string InterfaceName)
        {
            // Loop through types looking for one that implements the given interface
            foreach (Type t in DLL.GetTypes())
            {
                if (t.GetInterface(InterfaceName, true) != null)
                    return DLL.CreateInstance(t.FullName);
            }

            return null;
        }
    }
}
