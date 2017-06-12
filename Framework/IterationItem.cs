using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace BOG.Framework
{
	//[Serializable]
	//class IterationItem : ISerializable, ICloneable
	//{
	//	string Name = string.Empty;
	//	SerializableDictionary<int, string> IterationValues = new SerializableDictionary<int, string>();
	//}

	/// <summary>
	/// Represents the values for a single iteration, used in a set of iterations.
	/// </summary>
	[Serializable]
	public class IterationItem : ISerializable, ICloneable
	{
		private string _Name = string.Empty;
		private SerializableDictionary<int, string> _IterationValues = new SerializableDictionary<int, string>();

		/// <summary>
		/// Creates an uninitialized object.
		/// </summary>
		public IterationItem()
		{
		}

		/// <summary>
		/// Creates an object with the specified iteration.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="iterationValues"></param>
		public IterationItem(string name, SerializableDictionary<int, string> iterationValues)
		{
			this._Name = name;
			this._IterationValues = iterationValues;
		}

		/// <summary>
		/// Created an iteration item from an existing object.
		/// </summary>
		/// <param name="obj"></param>
		public IterationItem(IterationItem obj)
		{
			this.Load(obj);
		}

		/// <summary>
		/// Creates an iteration item from ordinal objects.
		/// </summary>
		/// <param name="obj"></param>
		public IterationItem(object[] obj)
		{
			this._Name = (string) obj[0];
			this._IterationValues = (SerializableDictionary<int, string>) obj[1];
		}

		/// <summary>
		/// Creates an iteration item from de-serialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public IterationItem(SerializationInfo info, StreamingContext context)
		{
			if (info != null)
			{
				this._Name = (string) info.GetValue("Name", typeof(string));
				this._IterationValues = (SerializableDictionary<int, string>) info.GetValue("IterationValues", typeof(SerializableDictionary<int, string>));
			}
		}

		/// <summary>
		/// Loads the existing instance with replacement values for its properties.
		/// </summary>
		/// <param name="obj"></param>
		public void Load(IterationItem obj)
		{
			this._Name = obj.Name;
			this._IterationValues = obj.IterationValues;
		}

		/// <summary>
		/// The name of the iteration.
		/// </summary>
		public string Name
		{
			get { return this._Name; }
			set { this._Name = value; }
		}

		/// <summary>
		/// The set of value in the iteration.
		/// </summary>
		public SerializableDictionary<int, string> IterationValues
		{
			get { return this._IterationValues; }
			set { this._IterationValues = value; }
		}

		/// <summary>
		/// Creates a new instance populated by the properties of this instance.
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			return new IterationItem(this);
		}

		/// <summary>
		/// Creates a new instance populated by the properties of this instance. (pseudonym)
		/// </summary>
		/// <returns></returns>
		public object CloneNew()
		{
			return this.Clone();
		}

		/// <summary>
		/// Returns properties from this instance for a serializer.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// base.GetObjectData(info, context);

			if (info == null)
			{
				throw new System.ArgumentNullException("Not a valid object");
			}

			info.AddValue("Name", this._Name);
			info.AddValue("IterationValues", this._IterationValues);
		}
	}
}