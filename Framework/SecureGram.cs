using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using BOG.Framework;

namespace BOG.Framework
{
	//[Serializable]
	//class SecureGram : ICloneable, ISerializable
	//{
	//	string Sender = string.Empty;
	//	string Created = string.Empty;
	//	string Subject = string.Empty;
	//	Int32 MessageLength = -1;
	//	bool IsCompressed = false;
	//	string Message = null;
	//}

	[Serializable]
	public class SecureGram : ICloneable, ISerializable
	{
		private string _sender = string.Empty;
		private string _created = string.Empty;
		private string _subject = string.Empty;
		private Int32 _messageLength = -1;
		private bool _isCompressed = false;
		private string _message = null;

		/// <summary>
		/// Initializes a new instance of the <see cref="SecureGram"/> class.
		/// </summary>
		public SecureGram()
		{
		}

		/// <summary>
		/// Constructor for deserialization.
		/// </summary>
		/// <param name="info">Provided by the serializer.</param>
		/// <param name="context">Provided by the serializer.</param>
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public SecureGram(SerializationInfo info, StreamingContext context)
		{
			// base.GetObjectData(info, context);

			if (info == null)
			{
				throw new System.ArgumentNullException("Not a valid object");
			}

			this._sender = (string) info.GetString("Sender");
			this._created = (string) info.GetString("Created");
			this._subject = (string) info.GetString("Subject");
			this._messageLength = (Int32) info.GetInt32("MessageLength");
			this._isCompressed = (bool) info.GetBoolean("IsCompressed");
			this._message = (string) info.GetString("Message");
		}

		/// <summary>
		/// Initializes a new instance of the class <see cref="SecureGram"/>, with all properties as parameters.
		/// </summary>
		/// <param name="Sender">The value to assign to this property</param>
		/// <param name="Created">The value to assign to this property</param>
		/// <param name="Subject">The value to assign to this property</param>
		/// <param name="MessageLength">The value to assign to this property</param>
		/// <param name="IsCompressed">The value to assign to this property</param>
		/// <param name="Message">The value to assign to this property</param>
		public SecureGram(string sender, string created, string subject, Int32 messageLength, bool isCompressed, string message)
		{
			this._sender = sender;
			this._created = created;
			this._subject = subject;
			this._messageLength = messageLength;
			this._isCompressed = isCompressed;
			this._message = message;
		}

		/// <summary>
		/// Initializes a new instance of the class <see cref="SecureGram"/>, using an existing instance as the parameter.
		/// </summary>
		/// <param name="obj">The existing instance source for the property values.</param>
		public SecureGram(SecureGram obj)
		{
			this.Load(obj);
		}

		/// <summary>
		/// Initializes a new instance of the class <see cref="SecureGram"/>, using an array of objects for the property values.
		/// </summary>
		/// <param name="obj">The property values in an object array, to assign ordinally.</param>
		public SecureGram(IReadOnlyList<object> obj)
		{
			this._sender = (string) obj[0];
			this._created = (string) obj[1];
			this._subject = (string) obj[2];
			this._messageLength = (Int32) obj[3];
			this._isCompressed = (bool) obj[4];
			this._message = (string) obj[5];
		}

		/// <summary>
		/// Load the properties of this instance, from the properties of another instance of the class <see cref="SecureGram"/>.
		/// </summary>
		/// <param name="obj">The existing object instance source for the property values.</param>
		public void Load(SecureGram obj)
		{
			this._sender = obj.Sender;
			this._created = obj.Created;
			this._subject = obj.Subject;
			this._messageLength = obj.MessageLength;
			this._isCompressed = obj.IsCompressed;
			this._message = obj.Message;
		}

		/// <summary>
		/// Load the properties of this instance, from a KeyValuePair collection.
		/// </summary>
		/// <param name="params">The KeyValuePair collection for the property values.</param>
		public void Load(List<KeyValuePair<string, object>> parms)
		{
			foreach (KeyValuePair<string, object> item in parms)
			{
				if (string.Compare(item.Key, "Sender", false) == 0)
				{
					this._sender = (string) item.Value;
				}
				else if (string.Compare(item.Key, "Created", false) == 0)
				{
					this._created = (string) item.Value;
				}
				else if (string.Compare(item.Key, "Subject", false) == 0)
				{
					this._subject = (string) item.Value;
				}
				else if (string.Compare(item.Key, "MessageLength", false) == 0)
				{
					this._messageLength = (Int32) item.Value;
				}
				else if (string.Compare(item.Key, "IsCompressed", false) == 0)
				{
					this._isCompressed = (bool) item.Value;
				}
				else if (string.Compare(item.Key, "Message", false) == 0)
				{
					this._message = (string) item.Value;
				}
				else
				{
					throw new Exception(string.Format("{0} is not a property member of this class. The property is case sensitive.", item.Key));
				}
			}
		}

		/// <summary>
		/// Gets or sets the value of this property.
		/// </summary>
		public string Sender
		{
			get { return this._sender; }
			set { this._sender = value; }
		}

		/// <summary>
		/// Gets or sets the value of this property.
		/// </summary>
		public string Created
		{
			get { return this._created; }
			set { this._created = value; }
		}

		/// <summary>
		/// Gets or sets the value of this property.
		/// </summary>
		public string Subject
		{
			get { return this._subject; }
			set { this._subject = value; }
		}

		/// <summary>
		/// Gets or sets the value of this property.
		/// </summary>
		public Int32 MessageLength
		{
			get { return this._messageLength; }
			set { this._messageLength = value; }
		}

		/// <summary>
		/// Gets or sets the value of this property.
		/// </summary>
		public bool IsCompressed
		{
			get { return this._isCompressed; }
			set { this._isCompressed = value; }
		}

		/// <summary>
		/// Gets or sets the value of this property.
		/// </summary>
		public string Message
		{
			get { return this._message; }
			set { this._message = value; }
		}

		/// <summary>
		/// Creates a new instance of this object with its property values.
		/// </summary>
		public object Clone()
		{
			return new SecureGram(this);
		}

		/// <summary>
		/// Creates a new instance of this object with its property values.
		/// </summary>
		public object CloneNew()
		{
			return this.Clone();
		}

		/// Serializable support method: returns the property values to a serialization client object.
		/// </summary>
		/// <param name="info">Provided by the serializer.</param>
		/// <param name="context">Provided by the serializer.</param>
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// base.GetObjectData(info, context);

			if (info == null)
			{
				throw new System.ArgumentNullException("Not a valid object");
			}

			info.AddValue("Sender", this._sender);
			info.AddValue("Created", this._created);
			info.AddValue("Subject", this._subject);
			info.AddValue("MessageLength", this._messageLength);
			info.AddValue("IsCompressed", this._isCompressed);
			info.AddValue("Message", this._message);
		}

		/// <summary>
		/// Takes a string with the content of the encrypted message, and decrypts/decompresses/validates the content.
		/// Uses the default encrypton method.
		/// </summary>
		/// <param name="encryptedContent"></param>
		/// <param name="key"></param>
		/// <param name="salt"></param>
		public void LoadGramContent(string encryptedContent, string key, string salt)
		{
			LoadGramContent<AesManaged>(encryptedContent, key, salt);
		}

		/// <summary>
		/// Takes a string with the content of the encrypted message, and decrypts/decompresses/validates the content.
		/// Client provides the encryption method to use as <typeparam name="T">SymmetricAlgorithm</typeparam>.
		/// </summary>
		/// <param name="encryptedContent"></param>
		/// <param name="key"></param>
		/// <param name="salt"></param>
		public void LoadGramContent<T>(string encryptedContent, string key, string salt)
			where T : SymmetricAlgorithm, new()
		{
			CipherUtility cipher = new CipherUtility(new T());
			this.Load(
				ObjectJsonSerializer<SecureGram>.CreateObjectFormat(
					cipher.Decrypt(
						encryptedContent,
						key,
						salt)));
			if (this._isCompressed)
			{
				MemoryStream messageCompressed = new MemoryStream(Convert.FromBase64String(this._message));
				StringBuilder result = new StringBuilder();
				using (var inGZipStream = new GZipStream(messageCompressed, CompressionMode.Decompress))
				{
					const int size = 16384;
					byte[] buffer = new byte[size];
					int count = 0;
					int TotalWritten = 0;
					while (TotalWritten < this._messageLength)
					{
						count = inGZipStream.Read(buffer, 0, size);
						if (TotalWritten + count > this._messageLength)
						{
							count = this._messageLength - TotalWritten;
						}
						for (int index = 0; index < count; index++)
						{
							result.Append((char) buffer[index]);
						}
						TotalWritten += count;
					}
				}
				this._message = result.ToString();
			}
		}

		/// <summary>
		/// Creates the encrypted Datagram for the current instance.
		/// Uses the default encryption method.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="salt"></param>
		/// <returns></returns>
		public string CreateGramContent(string key, string salt)
		{
			return CreateGramContent<AesManaged>(key, salt);
		}

		/// <summary>
		/// Creates the encrypted Datagram.
		/// Client provides the encryption method to use as <typeparam name="T">SymmetricAlgorithm</typeparam>.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="salt"></param>
		/// <returns></returns>
		public string CreateGramContent<T>(string key, string salt)
			where T : SymmetricAlgorithm, new()
		{
			DateTime Now = DateTime.Now.ToUniversalTime();
			this._created = string.Format("{0:yyyy-MM-dd-TZ-HH:mm:ss.fff}", Now);
			this._messageLength = this._message.Length;
			StringBuilder SaltedMessage = new StringBuilder(this.Message);
			Random r = new Random((int) DateTime.Now.Ticks);
			int charCount = r.Next(3, 25);
			for (int charIndex = 0; charIndex < charCount; charIndex++)
			{
				SaltedMessage.Append((char) r.Next(32, 90));
			}
			SecureGram work = new SecureGram(this);
			work.IsCompressed = this._messageLength >= 10000;
			if (work.IsCompressed)
			{
				MemoryStream messageCompressed = new MemoryStream();
				using (var outGZipStream = new GZipStream(messageCompressed, CompressionLevel.Optimal))
				{
					using (StreamWriter sw = new StreamWriter(outGZipStream))
					{
						sw.Write(SaltedMessage.ToString());
						sw.Close();
					}
				}
				work.Message = Convert.ToBase64String(messageCompressed.ToArray());
			}

			CipherUtility cipher = new CipherUtility(new T());
			return
				cipher.Encrypt(
					ObjectJsonSerializer<SecureGram>.CreateDocumentFormat(work),
					key,
					salt, 
					Base64FormattingOptions.InsertLineBreaks);
		}
	}
}
