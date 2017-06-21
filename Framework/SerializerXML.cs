using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BOG.Framework
{
	/// <summary>
	/// Provides XML serialization/deserialization functionality.
	///
	/// example usage:
	/// MyObject t = new MyObject();
	/// 
	/// t.MyProperty1 = this.txtTitle.Text;
	/// ....
	/// string xmldoc = ObjectXMLSerializer&lt;MyObject&gt;.CreateDocumentFormat(t);
	/// ObjectXMLSerializer&lt;MyObject&gt;.SaveDocumentFormat(t, filename);
	/// string xmldoc = ObjectXMLSerializer&lt;MyObject&gt;.LoadDocumentFormat(filename);
	/// t = ObjectXMLSerializer&lt;MyObject&gt;.CreateObjectFormat(xmldoc);
	/// </summary>
	/// <typeparam name="T">Any serializable class</typeparam>
	public static class ObjectXMLSerializer<T> where T : class
	{
		private const int _16M = 16 * 1024 * 1024;

		private static XmlSerializer CreateXmlSerializer(System.Type[] extraTypes)
		{
			Type ObjectType = typeof(T);

			XmlSerializer xmlSerializer = null;

			if (extraTypes != null)
				xmlSerializer = new XmlSerializer(ObjectType, extraTypes);
			else
				xmlSerializer = new XmlSerializer(ObjectType);

			return xmlSerializer;
		}

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
		/// <param name="serializableObject">The object to be serialized into XML</param>
		/// <returns>a string containing the XML</returns>
		public static string CreateDocumentFormat(T serializableObject)
		{
			MemoryStream o = new MemoryStream();
			XmlSerializer xmlSerializer = CreateXmlSerializer(null);
			xmlSerializer.Serialize(o, serializableObject);
			return ByteToString(o.ToArray());
		}

		/// <summary>
		/// Creates an object from a string containing serialized XML of an instance of an object of that class type.
		/// </summary>
		/// <param name="xml">the string containing the serialized XML</param>
		/// <returns>An object with the deserialized content</returns>
		public static T CreateObjectFormat(string xml)
		{
			T serializableObject = null;
			MemoryStream o = new MemoryStream();
			System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
			byte[] b = encoding.GetBytes(xml);
			o.Write(b, 0, b.Length);
			o.Position = 0;
			XmlSerializer xmlSerializer = CreateXmlSerializer(null);
			serializableObject = (T) xmlSerializer.Deserialize(o);
			return serializableObject;
		}

		/// <summary>
		/// Persists XML serialized from the object into a file.  This uses memory streams, so the serialized object
		/// can not exceeed 2Gb.
		/// </summary>
		/// <param name="serializableObject">The object to serialize</param>
		/// <param name="filename">The file in which to store the serialized content.</param>
		public static void SaveDocumentFormat(T serializableObject, string filename)
		{
			using (StreamWriter sw = File.CreateText(filename))
			{
				XmlSerializer xmlSerializer = CreateXmlSerializer(null);
				xmlSerializer.Serialize(sw, serializableObject);
				sw.Close();
			}
		}

		/// <summary>
		/// Persists XML serialized from the object into a gzip file.  This uses memory streams, so the serialized object
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
					XmlSerializer xmlSerializer = CreateXmlSerializer(null);
					xmlSerializer.Serialize(sw, serializableObject);
					sw.Close();
				}
			}
		}

		/// <summary>
		/// Takes an object, serializes it to JSON, compresses it with GZip, encrypts it, then creates a Base64 string
		/// of its content. This string becomes the (secure) transit container for the receiver.
		/// </summary>
		/// <param name="serializableObject">The object to serialize</param>
		/// <param name="password">The password used for encryption.</param>
		/// <param name="salt">The salt used for encryption.</param>
		public static string CreateTransitContainerForObject(T serializableObject, string password, string salt)
		{
			return CreateTransitContainerForObject(serializableObject, password, salt, new AesManaged());
		}

		/// <summary>
		/// Takes an object, serializes it to JSON, compresses it with GZip, encrypts it, then creates a Base64 string
		/// of its content. This string becomes the (secure) transit container for the receiver.
		/// This overload allows a specific method to be used for the encryption.
		/// </summary>
		/// <param name="serializableObject">The object to serialize</param>
		/// <param name="password">The password used for encryption.</param>
		/// <param name="salt">The salt used for encryption.</param>
		/// <param name="algorithm">an instance of an inheriting class of SymmetricAlgorithm to do the encryption.</param>
		public static string CreateTransitContainerForObject(T serializableObject, string password, string salt, SymmetricAlgorithm algorithm)
		{
			using (MemoryStream m = new MemoryStream())
			{
				using (System.IO.Compression.GZipStream outGZipStream = new GZipStream(m, CompressionMode.Compress))
				{
					using (StreamWriter sw = new StreamWriter(outGZipStream))
					{
						sw.Write(CreateDocumentFormat(serializableObject));
					}
				}
				return new CipherUtility(algorithm).EncryptByteArray(m.ToArray(), password, salt, Base64FormattingOptions.InsertLineBreaks);
			}
		}

		/// <summary>
		/// Takes the (secure) transit container, a Base64 string, decrypts it, decompresses it with GZip (to JSON), 
		/// and returns the deserialized object.
		/// </summary>
		/// <param name="secureBase64">The string with the transit container content</param>
		/// <param name="password">The password used for encryption.</param>
		/// <param name="salt">The salt used for encryption.</param>
		public static T CreateObjectFromTransitContainer(string secureBase64, string password, string salt)
		{
			return CreateObjectFromTransitContainer(secureBase64, password, salt, new AesManaged());
		}

		/// <summary>
		/// Takes the (secure) transit container, a Base64 string, decrypts it, decompresses it with GZip (to JSON), 
		/// and returns the deserialized object.
		/// This overload allows a specific method to be used for the decryption.
		/// </summary>
		/// <param name="secureBase64">The string with the transit container content</param>
		/// <param name="password">The password used for encryption.</param>
		/// <param name="salt">The salt used for encryption.</param>
		/// <param name="algorithm">an instance of an inheriting class of SymmetricAlgorithm to do the encryption.</param>
		public static T CreateObjectFromTransitContainer(string secureBase64, string password, string salt, SymmetricAlgorithm algorithm)
		{
			T serializableObject = null;

			using (MemoryStream m = new MemoryStream(new CipherUtility(algorithm).DecryptByteArray(secureBase64, password, salt)))
			{
				using (System.IO.Compression.GZipStream inGZipStream = new GZipStream(m, CompressionMode.Decompress))
				{
					using (StreamReader sr = new StreamReader(inGZipStream))
					{
						serializableObject = CreateObjectFormat(sr.ReadToEnd());
					}
				}
				return serializableObject;
			}
		}


		/// <summary>
		/// Creates an object from a compressed file containing serialized XML of an instance of an object of that class type.
		/// </summary>
		/// <param name="filename">the file containing the serialized XML</param>
		/// <returns>An object with the deserialized content</returns>
		public static T LoadDocumentFormat(string filename)
		{
			T serializableObject = null;
			using (StreamReader o = new StreamReader(filename))
			{
				XmlSerializer xmlSerializer = CreateXmlSerializer(null);
				serializableObject = (T) xmlSerializer.Deserialize(o);
				o.Close();
			}
			return serializableObject;
		}

		/// <summary>
		/// Creates an object from a gzip file, containing serialized XML of an instance of an object of that class type.
		/// </summary>
		/// <param name="compressedFilename">the gzip file containing the serialized XML</param>
		/// <returns>An object with the deserialized content</returns>
		public static T LoadCompressedDocumentFormat(string compressedFilename)
		{
			T serializableObject = null;
			using (GZipStream inGZipStream = new GZipStream(File.OpenRead(compressedFilename), CompressionMode.Decompress))
			{
				using (StreamReader o = new StreamReader(inGZipStream))
				{
					XmlSerializer xmlSerializer = CreateXmlSerializer(null);
					serializableObject = (T) xmlSerializer.Deserialize(o);
					o.Close();
				}
			}
			return serializableObject;
		}
	}
}