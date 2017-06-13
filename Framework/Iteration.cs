using System;
using System.Collections.Generic;
using System.Linq;

namespace BOG.Framework
{
	/// <summary>
	/// Allows Parameter sets to be added for loops, and allows the lopp enumerations to be represented by an index, and
	/// vice-versa.  Intended to support large and deep looping with millions to even trillions of combinations.
	/// </summary>
	public class Iteration
	{
		/// <summary>
		/// EndValueEval is for numeric sequences, and specifies how the range limit value is handled.
		/// </summary>
		public enum EndValueEval : int {
			/// <summary>
			/// The range limit should be used      ( 1 &lt;= x &lt;= Value )
			/// </summary>
			Inclusive = 0,
			/// <summary>
			/// The range limit should not be used  ( 1 &lt;= x &lt; Value )
			/// </summary>
			Exclusive = 1
		}

		private SerializableDictionary<int, IterationItem> _IterationItems = new SerializableDictionary<int, IterationItem>();
		private long _TotalIterationCount = 0L;

		/// <summary>
		/// Gets the number of items in this iteration.
		/// </summary>
		public long TotalIterationCount { get { return _TotalIterationCount; } }

		/// <summary>
		/// Gets a copy of the iteration set, or sets the iteration set values.
		/// </summary>
		public SerializableDictionary<int, IterationItem> IterationItems
		{
			get
			{
				SerializableDictionary<int, IterationItem> returnValue = new SerializableDictionary<int, IterationItem>();
				foreach (int key in _IterationItems.Keys)
				{
					returnValue.Add(key, (IterationItem) _IterationItems[key].Clone());
				}
				return returnValue;
			}
			set
			{
				_IterationItems.Clear();
				foreach (int key in value.Keys)
				{
					_IterationItems.Add(key, (IterationItem) value[key].Clone());
					_TotalIterationCount = (_TotalIterationCount == 0L ? 1L : _TotalIterationCount) * _IterationItems[key].IterationValues.Count;
				}
			}
		}

		/// <summary>
		/// Creates a default instantiation.
		/// </summary>
		public Iteration()
		{
		}

		/// <summary>
		/// Gets whether an iteration with a specific name already exists in the iteration items.
		/// </summary>
		/// <param name="name"></param>
		/// <returns>false if not found</returns>
		public bool IterationItemNameExists(string name)
		{
			bool result = false;
			foreach (int key in _IterationItems.Keys)
			{
				// SerializableDictionary<> and Dictionary<> are case-sensitive when the key is a string.
				if (string.Compare(_IterationItems[key].Name, name, false) == 0)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		/// <summary>
		/// Gets a list of the items associated with an iteration name.
		/// </summary>
		/// <param name="forName">the iteration name.</param>
		/// <returns>A dictionary of the items, with the key being the ordinal sequence (0...N)</returns>
		public SerializableDictionary<int, IterationItem> GetIterationItemsForName(string forName)
		{
			SerializableDictionary<int, IterationItem> result = new SerializableDictionary<int, IterationItem>();
			if (IterationItemNameExists(forName))
			{
				foreach (int key in _IterationItems.Keys)
				{
					if (_IterationItems[key].Name != forName)
					{
						continue;
					}
					result.Add(key, _IterationItems[key]);
				}
			}
			return result;
		}

		/// <summary>
		/// Add numbers by range and increment as an iteration item.  This is equivalent to:
		/// for (double value = initialValue, value &lt; limitValue, value += incrementValue)  // when increment is positive
		/// for (double value = initialValue, value &gt; limitValue, value -= incrementValue)  // when increment is negative
		/// </summary>
		/// <param name="name">Name of the parameter</param>
		/// <param name="initialValue">the starting value</param>
		/// <param name="incrementValue">the step or increment to the next value</param>
		/// <param name="limitValue">the end value</param>
		/// <param name="endValueEval">whether the end value itself can be included in the list of items.</param>
		/// <returns>The number of items created for the iteration item.</returns>
		public int AddNumberRange(string name, double initialValue, double incrementValue, double limitValue, EndValueEval endValueEval)
		{
			if (IterationItemNameExists(name))
			{
				throw new ArgumentException(string.Format("The name \"{0}\" is already used by another itermation item.", name));
			}

			if (Math.Sign(incrementValue) == 1 && initialValue > limitValue)
			{
				throw new ArgumentException(string.Format("The increment value for \"{0}\" can not be zero.", name));
			}

			if ((limitValue > initialValue && Math.Sign(incrementValue) == -1) || (initialValue > limitValue && Math.Sign(incrementValue) == 1))
			{
				throw new ArgumentException(string.Format(
					"The increment value must be {0} to iterate from {1} to {2}",
					Math.Sign(incrementValue) == -1 ? "positive" : "negative",
					initialValue,
					limitValue));
			}

			int result = 0;
			IterationItem item = new IterationItem();
			item.Name = name;
			item.IterationValues = new SerializableDictionary<int, string>();
			double v = initialValue;
			if (Math.Sign(incrementValue) == -1)
			{
				limitValue += endValueEval == EndValueEval.Inclusive ? -1 : 0;
			}
			else
			{
				limitValue += endValueEval == EndValueEval.Inclusive ? 1 : 0;
			}

			bool keepGoing = true;
			while (keepGoing)
			{
				keepGoing = Math.Sign(incrementValue) == -1 ? (v > limitValue) : (v < limitValue);
				if (!keepGoing)
				{
					break;
				}
				item.IterationValues.Add(item.IterationValues.Count, v.ToString());
				v += incrementValue;
			}
			result = item.IterationValues.Count;
			if (result == 0)
			{
				throw new ArgumentException(string.Format("The name \"{0}\" has no items: at least one must be defined.", name));
			}
			_IterationItems.Add(_IterationItems.Count, item);
			_TotalIterationCount = (_TotalIterationCount == 0L ? 1L : _TotalIterationCount) * item.IterationValues.Count;
			return result;
		}

		/// <summary>
		/// Add numbers by start and loop count.
		/// </summary>
		/// <param name="name">Name of the parameter</param>
		/// <param name="initialValue">the starting value</param>
		/// <param name="incrementValue">the step or increment to the next value</param>
		/// <param name="iterationCount">the number of times to increment the value and add the new value to list.</param>
		/// <returns>The number of items created for the iteration item.</returns>
		public int AddNumberSequence(string name, double initialValue, double incrementValue, int iterationCount)
		{
			if (IterationItemNameExists(name))
			{
				throw new ArgumentException(string.Format("The name \"{0}\" is already used by another itermation item.", name));
			}

			if (Math.Sign(incrementValue) == 0.0)
			{
				throw new ArgumentException(string.Format("The increment value for \"{0}\" can not be zero.", name));
			}

			int result = 0;
			IterationItem item = new IterationItem();
			item.Name = name;
			item.IterationValues = new SerializableDictionary<int, string>();
			double v = initialValue;
			while (iterationCount > 0)
			{
				item.IterationValues.Add(item.IterationValues.Count, v.ToString());
				v += incrementValue;
				iterationCount--;
			}
			result = item.IterationValues.Count;
			if (result == 0)
			{
				throw new ArgumentException(string.Format("The name \"{0}\" has no items: at least one must be defined.", name));
			}
			_IterationItems.Add(_IterationItems.Count, item);
			_TotalIterationCount = (_TotalIterationCount == 0L ? 1L : _TotalIterationCount) * item.IterationValues.Count;
			return result;
		}

		/// <summary>
		/// Adds items from a list of items.  This allows non-sequence values to be added. Eg.
		/// { "91352", 66202", "34761" }   // zip codes
		/// { "Fred", "Harry", "Sally" }
		/// 
		/// </summary>
		/// <param name="name">The iteration item name</param>
		/// <param name="itemValues"></param>
		/// <returns></returns>
		public int AddListItems(string name, List<string> itemValues)
		{
			if (IterationItemNameExists(name))
			{
				throw new ArgumentException(string.Format("The name \"{0}\" is already used by another itermation item.", name));
			}

			if (itemValues == null || itemValues.Count == 0)
			{
				throw new ArgumentException(string.Format("The list of items to add can not be empty.", name));
			}

			int result = 0;
			IterationItem item = new IterationItem();
			item.Name = name;
			item.IterationValues = new SerializableDictionary<int, string>();
			foreach (string value in itemValues)
			{
				item.IterationValues.Add(item.IterationValues.Count, value);
			}
			result = item.IterationValues.Count;
			if (result == 0)
			{
				throw new ArgumentException(string.Format("The name \"{0}\" has no items: at least one must be defined.", name));
			}
			_IterationItems.Add(_IterationItems.Count, item);
			_TotalIterationCount = (_TotalIterationCount == 0L ? 1L : _TotalIterationCount) * item.IterationValues.Count;
			return result;
		}

		/// <summary>
		/// Returns the items and their values for a particular index.
		/// </summary>
		/// <param name="indexSpecific">The zero-based index of the sequence.</param>
		/// <returns>A dictionary of strings where the key is the IterationItem name, and the value is its value for this index.</returns>
		public Dictionary<string, string> GetIterationValueSet(Int64 indexSpecific)
		{
			if (indexSpecific < 0)
			{
				throw new ArgumentException("The requested index can not be negative.");
			}
			if (indexSpecific > _TotalIterationCount)
			{
				throw new ArgumentException(
					string.Format("The requested index ({0}) is beyond the maximum of {1}",
					indexSpecific,
					_TotalIterationCount - 1));
			}

			long index = indexSpecific;
			Dictionary<string, string> result = new Dictionary<string, string>();
			for (int ItemInSetIndex = _IterationItems.Count - 1; ItemInSetIndex >= 0; ItemInSetIndex--)
			{
				Int64 whole = index / (Int64) _IterationItems[ItemInSetIndex].IterationValues.Count;
				int remainder = (int) (index % (Int64) _IterationItems[ItemInSetIndex].IterationValues.Count);
				result.Add(_IterationItems[ItemInSetIndex].Name, _IterationItems[ItemInSetIndex].IterationValues[remainder]);
				index = whole;
			}

			return result;
		}
	}
}
