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

	[Serializable]
	public class IterationItem : ISerializable, ICloneable
	{
		private string _Name = string.Empty;
		private SerializableDictionary<int, string> _IterationValues = new SerializableDictionary<int, string>();

		public IterationItem()
		{
		}

		public IterationItem(string name, SerializableDictionary<int, string> iterationValues)
		{
			this._Name = name;
			this._IterationValues = iterationValues;
		}

		public IterationItem(IterationItem obj)
		{
			this.Load(obj);
		}

		public IterationItem(object[] obj)
		{
			this._Name = (string) obj[0];
			this._IterationValues = (SerializableDictionary<int, string>) obj[1];
		}

		// For serialization/de-serialization
		public IterationItem(SerializationInfo info, StreamingContext context)
		{
			if (info != null)
			{
				this._Name = (string) info.GetValue("Name", typeof(string));
				this._IterationValues = (SerializableDictionary<int, string>) info.GetValue("IterationValues", typeof(SerializableDictionary<int, string>));
			}
		}

		public void Load(IterationItem obj)
		{
			this._Name = obj.Name;
			this._IterationValues = obj.IterationValues;
		}

		public string Name
		{
			get { return this._Name; }
			set { this._Name = value; }
		}

		public SerializableDictionary<int, string> IterationValues
		{
			get { return this._IterationValues; }
			set { this._IterationValues = value; }
		}

		public object Clone()
		{
			return new IterationItem(this);
		}

		public object CloneNew()
		{
			return this.Clone();
		}

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