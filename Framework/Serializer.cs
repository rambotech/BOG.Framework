using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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
    public static class ObjectXMLSerializer<T> where T : class // Specify that T must be a class.
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
                s.Append((char)b[x]);
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
            serializableObject = (T)xmlSerializer.Deserialize(o);
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
        /// Creates an object from a compressed file containing serialized XML of an instance of an object of that class type.
        /// </summary>
        /// <param name="filename">the file containing the serialized XML</param>
        /// <returns>An object with the deserialized content</returns>
        public static T LoadDocumentFormat(string path)
        {
            T serializableObject = null;
            using (StreamReader o = new StreamReader(path))
            {
                XmlSerializer xmlSerializer = CreateXmlSerializer(null);
                serializableObject = (T)xmlSerializer.Deserialize(o);
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
                    serializableObject = (T)xmlSerializer.Deserialize(o);
                    o.Close();
                }
            }
            return serializableObject;
        }
    }
}