using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BOG.Framework_NUnit.Support
{
	//[Serializable]
	//class MyDataSet : ISerializable, ICloneable
	//{
	//	string s1 = "{default}";
	//	Int64 i64 = 841423572389523587;
	//	Int32 i32 = 1453123992;
	//	Int16 i16 = 32705;
	//	DateTime Timestamp = DateTime.Now;
	//	List<string> coll = new List<string>();
	//}

	public class MyDataSet : ISerializable, ICloneable
	{
		private string _s1 = "{default}";
		private Int64 _i64 = 841423572389523587;
		private Int32 _i32 = 1453123992;
		private Int16 _i16 = 32705;
		private DateTime _timestamp = DateTime.Now;
		private List<string> _coll = new List<string>();

		/// <summary>
		/// Initializes a new instance of the <see cref="MyDataSet"/> class.
		/// </summary>
		public MyDataSet()
		{
		}

		/// <summary>
		/// Constructor for deserialization.
		/// </summary>
		/// <param name="info">Provided by the serializer.</param>
		/// <param name="context">Provided by the serializer.</param>
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public MyDataSet(SerializationInfo info, StreamingContext context)
		{
			// base.GetObjectData(info, context);

			if (info == null)
			{
				throw new System.ArgumentNullException("Not a valid object");
			}

			this._s1 = (string) info.GetString("s1");
			this._i64 = (Int64) info.GetInt64("i64");
			this._i32 = (Int32) info.GetInt32("i32");
			this._i16 = (Int16) info.GetInt16("i16");
			this._timestamp = (DateTime) info.GetDateTime("Timestamp");
			this._coll = (List<string>) info.GetValue("coll", typeof(List<string>));
		}

		/// <summary>
		/// Initializes a new instance of the class <see cref="MyDataSet"/>, with all properties as parameters.
		/// </summary>
		/// <param name="s1">The value to assign to this property</param>
		/// <param name="i64">The value to assign to this property</param>
		/// <param name="i32">The value to assign to this property</param>
		/// <param name="i16">The value to assign to this property</param>
		/// <param name="Timestamp">The value to assign to this property</param>
		/// <param name="coll">The value to assign to this property</param>
		public MyDataSet(string s1, Int64 i64, Int32 i32, Int16 i16, DateTime timestamp, List<string> coll)
		{
			this._s1 = s1;
			this._i64 = i64;
			this._i32 = i32;
			this._i16 = i16;
			this._timestamp = timestamp;
			this._coll = coll;
		}

		/// <summary>
		/// Initializes a new instance of the class <see cref="MyDataSet"/>, using an existing instance as the parameter.
		/// </summary>
		/// <param name="obj">The existing instance source for the property values.</param>
		public MyDataSet(MyDataSet obj)
		{
			this.Load(obj);
		}

		/// <summary>
		/// Initializes a new instance of the class <see cref="MyDataSet"/>, using an array of objects for the property values.
		/// </summary>
		/// <param name="obj">The property values in an object array, to assign ordinally.</param>
		public MyDataSet(IReadOnlyList<object> obj)
		{
			this._s1 = (string) obj[0];
			this._i64 = (Int64) obj[1];
			this._i32 = (Int32) obj[2];
			this._i16 = (Int16) obj[3];
			this._timestamp = (DateTime) obj[4];
			this._coll = (List<string>) obj[5];
		}

		/// <summary>
		/// Load the properties of this instance, from the properties of another instance of the class <see cref="MyDataSet"/>.
		/// </summary>
		/// <param name="obj">The existing object instance source for the property values.</param>
		public void Load(MyDataSet obj)
		{
			this._s1 = obj.s1;
			this._i64 = obj.i64;
			this._i32 = obj.i32;
			this._i16 = obj.i16;
			this._timestamp = obj.Timestamp;
			this._coll = obj.coll;
		}

		/// <summary>
		/// Load the properties of this instance, from a KeyValuePair collection.
		/// </summary>
		/// <param name="params">The KeyValuePair collection for the property values.</param>
		public void Load(List<KeyValuePair<string, object>> parms)
		{
			foreach (KeyValuePair<string, object> item in parms)
			{
				if (string.Compare(item.Key, "s1", false) == 0)
				{
					this._s1 = (string) item.Value;
				}
				else if (string.Compare(item.Key, "i64", false) == 0)
				{
					this._i64 = (Int64) item.Value;
				}
				else if (string.Compare(item.Key, "i32", false) == 0)
				{
					this._i32 = (Int32) item.Value;
				}
				else if (string.Compare(item.Key, "i16", false) == 0)
				{
					this._i16 = (Int16) item.Value;
				}
				else if (string.Compare(item.Key, "Timestamp", false) == 0)
				{
					this._timestamp = (DateTime) item.Value;
				}
				else if (string.Compare(item.Key, "coll", false) == 0)
				{
					this._coll = (List<string>) item.Value;
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
		public string s1
		{
			get { return this._s1; }
			set { this._s1 = value; }
		}

		/// <summary>
		/// Gets or sets the value of this property.
		/// </summary>
		public Int64 i64
		{
			get { return this._i64; }
			set { this._i64 = value; }
		}

		/// <summary>
		/// Gets or sets the value of this property.
		/// </summary>
		public Int32 i32
		{
			get { return this._i32; }
			set { this._i32 = value; }
		}

		/// <summary>
		/// Gets or sets the value of this property.
		/// </summary>
		public Int16 i16
		{
			get { return this._i16; }
			set { this._i16 = value; }
		}

		/// <summary>
		/// Gets or sets the value of this property.
		/// </summary>
		public DateTime Timestamp
		{
			get { return this._timestamp; }
			set { this._timestamp = value; }
		}

		/// <summary>
		/// Gets or sets the value of this property.
		/// </summary>
		public List<string> coll
		{
			get { return this._coll; }
			set { this._coll = value; }
		}

		/// <summary>
		/// Creates a new instance of this object with its property values.
		/// </summary>
		public object Clone()
		{
			return new MyDataSet(this);
		}

		/// <summary>
		/// Creates a new instance of this object with its property values.
		/// </summary>
		public object CloneNew()
		{
			return this.Clone();
		}

		/// <summary>
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

			info.AddValue("s1", this._s1);
			info.AddValue("i64", this._i64);
			info.AddValue("i32", this._i32);
			info.AddValue("i16", this._i16);
			info.AddValue("Timestamp", this._timestamp);
			info.AddValue("coll", this._coll);
		}
	}
}
