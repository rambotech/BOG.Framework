using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

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
			/// <summary>
			/// 
			/// </summary>
			VBnet,
			/// <summary>
			/// 
			/// </summary>
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
				case Languages.VBnet:
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
		/// Returns a list of methods in a DLL which implement a specified interface.
		/// </summary>
		/// <param name="DLL">The assemly to search</param>
		/// <param name="InterfaceName">The name of the interface which is implemented.</param>
		/// <returns></returns>
		public static List<string> GetImplementersForInterface(System.Reflection.Assembly DLL, string InterfaceName)
		{
			List<string> Results = new List<string>();

			foreach (Type t in DLL.GetTypes())
			{
				if (t.GetInterface(InterfaceName, true) != null)
					Results.Add(t.FullName);
			}
			return Results;
		}

		/// <summary>
		/// Locate an interface in an assembly, which is needed to execute the assembly.
		/// </summary>
		/// <param name="DLL"></param>
		/// <param name="InterfaceName"></param>
		/// <returns>An instance of the first class implementing the interface</returns>
		public static object FindInterface(System.Reflection.Assembly DLL, string InterfaceName)
		{
			return FindInterface(DLL, InterfaceName, string.Empty);
		}

		/// <summary>
		/// Locate an interface in an assembly, with a specific implenter name, which is needed to execute the assembly.
		/// </summary>
		/// <param name="DLL">The Assembly containing the implementer</param>
		/// <param name="InterfaceName">The name of the interface</param>
		/// <param name="ImplementerName">The specific name of the implementer: empty string for the first occurrence.</param>
		/// <returns>An instance of the first class implementing the interface</returns>
		public static object FindInterface(System.Reflection.Assembly DLL, string InterfaceName, string ImplementerName)
		{
			// Loop through types looking for one that implements the given interface
			foreach (Type t in DLL.GetTypes())
			{
				if (t.GetInterface(InterfaceName, true) != null && (string.IsNullOrWhiteSpace(ImplementerName) || string.Compare(t.FullName, ImplementerName, false) == 0))
					return DLL.CreateInstance(t.FullName);
			}
			return null;
		}
	}
}
