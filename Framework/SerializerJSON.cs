using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BOG.Framework
{
	/// <summary>
	/// Provides JSON serialization/deserialization functionality, equivalent to its Json counterpart.
	///
	/// example usage:
	/// MyObject t = new MyObject();
	/// 
	/// t.MyProperty1 = this.txtTitle.Text;
	/// ....
	/// string Jsondoc = ObjectJsonSerializer&lt;MyObject&gt;.CreateDocumentFormat(t);
	/// ObjectJsonSerializer&lt;MyObject&gt;.SaveDocumentFormat(t, filename);
	/// string Jsondoc = ObjectJsonSerializer&lt;MyObject&gt;.LoadDocumentFormat(filename);
	/// t = ObjectJsonSerializer&lt;MyObject&gt;.CreateObjectFormat(Jsondoc);
	/// </summary>
	/// <typeparam name="T">Any serializable class</typeparam>
	public static class ObjectJsonSerializer<T> where T : class // Specify that T must be a class.
	{
		private const int _16M = 16 * 1024 * 1024;

		private static string ByteToString(byte[] b)
		{
			StringBuilder s = new StringBuilder();
			for (int x = 0; x < b.Length; ++x)
			{
				s.Append((char) b[x]);
			}
			return (s.ToString());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="serializableObject">The object to be serialized into JSON</param>
		/// <returns>a string containing the JSON</returns>
		public static string CreateDocumentFormat(T serializableObject)
		{
			return JsonConvert.SerializeObject(serializableObject);
		}

		/// <summary>
		/// Creates an object from a string containing serialized Json of an instance of an object of that class type.
		/// </summary>
		/// <param name="Json">the string containing the serialized Json</param>
		/// <returns>An object with the deserialized content</returns>
		public static T CreateObjectFormat(string json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}

		/// <summary>
		/// Persists JSON serialized from the object into a file.  This uses memory streams, so the serialized object
		/// can not exceeed 2Gb.
		/// </summary>
		/// <param name="serializableObject">The object to serialize</param>
		/// <param name="filename">The file in which to store the serialized content.</param>
		public static void SaveDocumentFormat(T serializableObject, string filename)
		{
			using (StreamWriter sw = File.CreateText(filename))
			{
				sw.Write(CreateDocumentFormat(serializableObject));
				sw.Close();
			}
		}

		/// <summary>
		/// Persists JSON serialized from the object into a gzip file.  This uses memory streams, so the serialized object
		/// can not exceeed 2Gb.
		/// </summary>
		/// <param name="serializableObject">The object to serialize</param>
		/// <param name="compressedFilename">The file in which to store the serialized content.</param>
		public static void SaveCompressedDocumentFormat(T serializableObject, string compressedFilename)
		{
			using (System.IO.Compression.GZipStream outGZipStream = new GZipStream(File.OpenWrite(compressedFilename), CompressionMode.Compress))
			{
				using (StreamWriter sw = new StreamWriter(outGZipStream))
				{
					sw.Write(CreateDocumentFormat(serializableObject));
					sw.Close();
				}
			}
		}

		/// <summary>
		/// Creates an object from a compressed file containing JSON representing an instance of an object of that class type.
		/// </summary>
		/// <param name="filename">the file containing JSON</param>
		/// <returns>An object with the deserialized content</returns>
		public static T LoadDocumentFormat(string filename)
		{
			T serializableObject = null;
			using (StreamReader o = new StreamReader(filename))
			{
				serializableObject = CreateObjectFormat(o.ReadToEnd());
				o.Close();
			}
			return serializableObject;
		}

		/// <summary>
		/// Creates an object from a gzip file, containing serialized JSON of an instance of an object of that class type.
		/// </summary>
		/// <param name="compressedFilename">the gzip file containing the serialized JSON</param>
		/// <returns>An object with the deserialized content</returns>
		public static T LoadCompressedDocumentFormat(string compressedFilename)
		{
			T serializableObject = null;
			using (GZipStream inGZipStream = new GZipStream(File.OpenRead(compressedFilename), CompressionMode.Decompress))
			{
				using (StreamReader o = new StreamReader(inGZipStream))
				{
					serializableObject = CreateObjectFormat(o.ReadToEnd());
					o.Close();
				}
			}
			return serializableObject;
		}
	}
}