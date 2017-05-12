using System;
using System.Collections.Generic;
using System.Linq;

namespace BOG.Framework
{
	public class Iteration
	{
		public enum EndValueEval : int { Inclusive = 0, Exclusive = 1 }

		private SerializableDictionary<int, IterationItem> _IterationItems = new SerializableDictionary<int, IterationItem>();
		private long _TotalIterationCount = 0L;

		// Read-only properties: returns a copy of the original.
		public long TotalIterationCount { get { return _TotalIterationCount; } }
		public SerializableDictionary<int, IterationItem> GetIterationItems {
			get {
				SerializableDictionary<int, IterationItem> returnValue = new SerializableDictionary<int, IterationItem>();
				foreach (int key in _IterationItems.Keys)
				{
					returnValue.Add(key, (IterationItem) _IterationItems[key].Clone());
				}
				return returnValue;
			}
		}

		public Iteration()
		{
		}

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
		/// <param name="initialValue"></param>
		/// <param name="incrementValue"></param>
		/// <param name="finalValue"></param>
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
		/// Add numbers by range, using an increment for as an iteration item.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="initialValue"></param>
		/// <param name="incrementValue"></param>
		/// <param name="iterationCount"></param>
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
		/// Adds items from a list of items.
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

		// returns the items and their values for a particular index.  The index reamins unchanged.
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
				//for (int ItemInSetIndex = 0; ItemInSetIndex < _IterationItems.Count; ItemInSetIndex++)
				//{
				Int64 whole = index / (Int64) _IterationItems[ItemInSetIndex].IterationValues.Count;
				int remainder = (int) (index % (Int64) _IterationItems[ItemInSetIndex].IterationValues.Count);
				result.Add(_IterationItems[ItemInSetIndex].Name, _IterationItems[ItemInSetIndex].IterationValues[remainder]);
				index = whole;
			}

			return result;
		}
	}
}
