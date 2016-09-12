using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOG.Framework
{
	/// <summary>
	/// An Item which is retained in the list, but marked as consumed.
	/// Allows a unique list, even if an item has been previously read.
	/// </summary>
	public class MemoryItem<T>
	{
		private T _value;
		private DateTime _consumed;
		private DateTime _recorded;

		/// <summary>
		/// This initialize is only for the use of an XMLSerializers
		/// </summary>
		public MemoryItem()
		{
		}

		/// <summary>
		/// Instantiates the object as a copy of an existing object.
		/// </summary>
		/// <param name="value"></param>
		public MemoryItem(T value)
		{
			_value = value;
			_consumed = DateTime.MinValue;
			_recorded = DateTime.Now;
		}

		/// <summary>
		/// Instantiates the object as a copy of an existing object, and keeps the recorded and consumed timestamps.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="recorded"></param>
		/// <param name="consumed"></param>
		public MemoryItem(T value, DateTime recorded, DateTime consumed)
		{
			_value = value;
			_consumed = consumed;
			_recorded = recorded;
		}

		/// <summary>
		/// The value of the memory item.
		/// </summary>
		public T Value
		{
			get { return _value; }
			set { _value = value; }
		}

		/// <summary>
		/// If the value is a datetime, the item has been consumed from the list.
		/// </summary>
		public DateTime Consumed
		{
			get { return _consumed; }
			set { _consumed = value; }
		}

		/// <summary>
		/// The datetime when the item was added to the list.
		/// </summary>
		public DateTime Recorded
		{
			get { return _recorded; }
			set { _recorded = value; }
		}
	}

	/// <summary>
	/// A list of MemoryItem, which can allow/disallow duplicate values, and allows values to be
	/// retrieved at random, or as a stack (FIFO) or a queue (LIFO).
	/// </summary>
	/// <typeparam name="T">The type of the value to store as an item in the list.</typeparam>
	public class MemoryList<T>
	{
		/// <summary>
		/// The method of retrieving items from the list.
		/// </summary>
		public enum MemoryListRetrieveSequence
		{
			/// <summary>
			/// No particular order.
			/// </summary>
			Random,
			/// <summary>
			/// Returns the last item added.
			/// </summary>
			Stack,
			/// <summary>
			/// Returns the first item added.
			/// </summary>
			Queue,
			/// <summary>
			/// synonym for Stack
			/// </summary>
			LIFO,
			/// <summary>
			/// synonym for Queue
			/// </summary>
			FIFO
		}
		Dictionary<long, MemoryItem<T>> _l = new Dictionary<long, MemoryItem<T>>();
		MemoryListRetrieveSequence _sequence = MemoryListRetrieveSequence.FIFO;
		string _Name = string.Empty;
		bool _UniqueValues = false;
		bool _IgnoreCase = true;
		long _ConsumedCount = 0;
		long _NextSerialNumber = 0;  // used to determine retrieve sequence

		/// <summary>
		/// Default instantiation
		/// </summary>
		public MemoryList()
		{
		}

		/// <summary>
		/// Parameterized instantiation
		/// </summary>
		/// <param name="name">The name of the list</param>
		/// <param name="uniqueValues">when true, values may not duplicate in the list.  Note: even when
		/// an existing value is consumed from the list, it is banned from being entered again.</param>
		/// <param name="ignoreCase"></param>
		public MemoryList(string name, bool uniqueValues, bool ignoreCase)
		{
			_Name = name;
			_UniqueValues = uniqueValues;
			_IgnoreCase = ignoreCase;
		}

		/// <summary>
		/// Parameterized instantiation
		/// </summary>
		/// <param name="name"></param>
		/// <param name="uniqueValues"></param>
		/// <param name="ignoreCase"></param>
		/// <param name="readSequence"></param>
		public MemoryList(string name, bool uniqueValues, bool ignoreCase, MemoryListRetrieveSequence readSequence)
		{
			_Name = name;
			_UniqueValues = uniqueValues;
			_IgnoreCase = ignoreCase;
			_sequence = readSequence;
		}

		/// <summary>
		/// Returns the sequence which items will be retrieved from the list.
		/// </summary>
		public MemoryListRetrieveSequence Sequence
		{
			get { return _sequence; }
			set { _sequence = value; }
		}

		/// <summary>
		/// Returns the name assigned to the list.
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		/// <summary>
		/// Whether values added to the list must have not previously been added.
		/// </summary>
		public bool UniqueValues
		{
			get { return _UniqueValues; }
			set { _UniqueValues = value; }
		}

		/// <summary>
		/// Whether to ignore case when comparing if an item already exists.
		/// </summary>
		public bool IgnoreCase
		{
			get { return _IgnoreCase; }
			set { _IgnoreCase = value; }
		}

		/// <summary>
		/// Returns all the items in the list, including consumed items.
		/// </summary>
		public List<MemoryItem<T>> ListItem
		{
			get
			{
				List<MemoryItem<T>> result = new List<MemoryItem<T>>();
				foreach (MemoryItem<T> item in _l.Values)
					result.Add(item);
				return result;
			}
			set
			{
				_l.Clear();
				_NextSerialNumber = 0;
				_ConsumedCount = 0;
				foreach (MemoryItem<T> item in value)
				{
					StoreValue(item.Value, item.Recorded, item.Consumed);
					if (item.Consumed != DateTime.MinValue)
						_ConsumedCount++;
				}
			}
		}

		/// <summary>
		/// Whether any unconsumed items exist.
		/// </summary>
		/// <returns></returns>
		public bool HasValues()
		{
			return (_l.Count - _ConsumedCount) > 0;
		}

		/// <summary>
		/// Returns the number of items already consumed from the list.
		/// </summary>
		/// <returns></returns>
		public long ConsumedCount()
		{
			return _ConsumedCount;
		}

		/// <summary>
		/// Returns the number of items not yet consumed from the list.
		/// </summary>
		/// <returns></returns>
		public long UnconsumedCount()
		{
			return _l.Count - _ConsumedCount;
		}

		/// <summary>
		/// Returns the number of consumed and unconsumed items from the list.
		/// </summary>
		/// <returns></returns>
		public long CountAll()
		{
			return _l.Count;
		}

		public void Clear()
		{
			_l.Clear();
			_NextSerialNumber = 0;
			_ConsumedCount = 0;
		}

		/// <summary>
		/// Add an item to the list.  Note: if uniqueness would be violated, the method reports success, but the item is not added.
		/// </summary>
		/// <param name="value"></param>
		public void StoreValue(T value)
		{
			StoreValue(value, DateTime.Now, DateTime.MinValue);
		}

		private void StoreValue(T value, DateTime recorded, DateTime consumed)
		{
			bool isString = value.GetType() == Type.GetType("System.String");
			if (_UniqueValues)
			{
				int i;
				for (i = 0; i < _l.Count; i++)
				{
					if (isString)
					{
						if (string.Compare(_l[i].Value.ToString(), value.ToString(), _IgnoreCase) == 0)
						{
							break;   // already in the list
						}
					}
					else
					{
						if (_l[i].Value.Equals(value))
						{
							break;   // already in the list
						}
					}
				}
				if (i < _l.Count)
				{
					return;  // prevents adding to the list.
				}
			}
			_l.Add(_NextSerialNumber++, new MemoryItem<T>(value, recorded, consumed));
			if (consumed != DateTime.MinValue)
				_ConsumedCount++;
		}

		/// <summary>
		/// Consume an item from the list.
		/// </summary>
		/// <returns></returns>
		public T RecallValue()
		{
			bool found = false;
			long Index = 0, Increment = 1, StopIndex = 0, UseIndex = -1;

			if ((_l.Count - _ConsumedCount) == 0)
			{
				throw new Exception("Method RecallValue() used against an empty or exhausted list.");
			}

			switch (_sequence)
			{
				case MemoryListRetrieveSequence.Random:
					Index = (long) (new Random().NextDouble() * (double) (_NextSerialNumber - 1));
					Increment = 1L;
					StopIndex = Index;
					break;

				case MemoryListRetrieveSequence.Queue:
				case MemoryListRetrieveSequence.FIFO:
					Index = 0L;
					Increment = 1L;
					StopIndex = _NextSerialNumber;
					break;

				case MemoryListRetrieveSequence.Stack:
				case MemoryListRetrieveSequence.LIFO:
					Index = _l.Count - 1;
					Increment = -1L;
					StopIndex = -1;
					break;
			}

			bool done = false;
			while (!done && !found)
			{
				if (_l[Index].Consumed == DateTime.MinValue)
				{
					found = true;
					UseIndex = Index;
					continue; // will leave the while() loop
				}

				Index += Increment;
				if (Index == StopIndex)
				{
					done = true;
					continue;
				}
				if (Index == _NextSerialNumber)
					Index = 0;
				else if (Index == -1)
					Index = _NextSerialNumber;
			}

			if (!found)
			{
				throw new Exception("Method RecallValue() used against an exhausted list.");
			}
			_l[UseIndex].Consumed = DateTime.Now;
			_ConsumedCount++;
			return _l[UseIndex].Value;
		}
	}
}