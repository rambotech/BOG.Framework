using System;
using System.Collections.Generic;
using System.Text;
using BOG.Framework;
using NUnit.Framework;

namespace BOG.Framework_NUnit
{
	[TestFixture]
	public class IterationTest
	{
		[Test, Description("IterationItem (List) count is accurate")]
		public void Iteration_List_areIterationItemsAndCountsOK()
		{
			Iteration iter = new Iteration();
			Assert.True(
				iter.GetIterationItems.Count == 0,
				"Count: expected {0}, got {1}",
				new object[] { 0, iter.GetIterationItems.Count });
			iter.AddListItems("ListItem", new List<string>(new string[] { "A", "B", "C" }));
			Assert.True(
				iter.GetIterationItems.Count == 1,
				"GetIterationItems.Count: expected {0}, got {1}",
				new object[] { 1, iter.GetIterationItems.Count });
			Assert.True(
				iter.IterationItemNameExists("ListItem"),
				"iter.IterationItemNameExists(\"ListItem\")",
				new object[] { "true", "false" });
			Assert.True(iter.TotalIterationCount == 3,
				"Count: expected {0}, got {1}",
				new object[] { 3, iter.TotalIterationCount });
			Assert.True(iter.TotalIterationCount == 3,
				"Count: expected {0}, got {1}",
				new object[] { 3, iter.TotalIterationCount });
			Dictionary<string, string> argSet = iter.GetIterationValueSet(0);
			Assert.True(
				argSet.ContainsKey("ListItem"),
				"argSet.ContainsKey(\"ListItem\"): expected {0}, got {1}",
				new object[] { "true", "false" });
			Assert.True(
				argSet.Count == 1,
				"argSet.Count: expected {0}, got {1}",
				new object[] { 1, argSet.Count == 1 });
			Assert.AreEqual(
				argSet["ListItem"],
				"A",
				"argSet[\"listitem\"]: expected {0}, got {1}",
				new object[] { "A", argSet["ListItem"] });
		}

		[Test, Description("IterationItem (NumberRange:Exclusive, positive) is accurate")]
		public void Iteration_NumberRange_areIterationItemsAndExclusiveCountsPositiveOK()
		{
			Iteration iter = new Iteration();
			Assert.True(
				iter.GetIterationItems.Count == 0,
				"Count: expected {0}, got {1}",
				new object[] { 0, iter.GetIterationItems.Count });
			iter.AddNumberRange("NumberRange-01", 0, 1, 10, Iteration.EndValueEval.Exclusive);
			Assert.True(
				iter.GetIterationItems.Count == 1,
				"Count: expected {0}, got {1}",
				new object[] { 1, iter.GetIterationItems.Count });
			Assert.True(iter.TotalIterationCount == 10,
				"Count: expected {0}, got {1}",
				new object[] { 10, iter.TotalIterationCount });
		}

		[Test, Description("IterationItem (NumberRange:Inclusive, positive) is accurate")]
		public void Iteration_NumberRange_areIterationItemsAndInclusivePositiveCountsOK()
		{
			Iteration iter = new Iteration();
			Assert.True(
				iter.GetIterationItems.Count == 0,
				"Count: expected {0}, got {1}",
				new object[] { 0, iter.GetIterationItems.Count });
			iter.AddNumberRange("NumberRange-01", 0, 1, 10, Iteration.EndValueEval.Inclusive);
			Assert.True(
				iter.GetIterationItems.Count == 1,
				"Count: expected {0}, got {1}",
				new object[] { 1, iter.GetIterationItems.Count });
			Assert.True(iter.TotalIterationCount == 11,
				"Count: expected {0}, got {1}",
				new object[] { 10, iter.TotalIterationCount });
		}

		[Test, Description("IterationItem (NumberRange:Exclusive, Negative) is accurate")]
		public void Iteration_NumberRange_areIterationItemsAndExclusiveCountsNegativeOK()
		{
			Iteration iter = new Iteration();
			Assert.True(
				iter.GetIterationItems.Count == 0,
				"Count: expected {0}, got {1}",
				new object[] { 0, iter.GetIterationItems.Count });
			iter.AddNumberRange("NumberRange-01", 10, -1, 0, Iteration.EndValueEval.Exclusive);
			Assert.True(
				iter.GetIterationItems.Count == 1,
				"Count: expected {0}, got {1}",
				new object[] { 1, iter.GetIterationItems.Count });
			Assert.True(iter.TotalIterationCount == 10,
				"Count: expected {0}, got {1}",
				new object[] { 10, iter.TotalIterationCount });
		}

		[Test, Description("IterationItem (NumberRange:Inclusive, Negative) is accurate")]
		public void Iteration_NumberRange_areIterationItemsAndInclusiveNegativeCountsOK()
		{
			Iteration iter = new Iteration();
			Assert.True(
				iter.GetIterationItems.Count == 0,
				"Count: expected {0}, got {1}",
				new object[] { 0, iter.GetIterationItems.Count });
			iter.AddNumberRange("NumberRange-01", 10, -1, 0, Iteration.EndValueEval.Inclusive);
			Assert.True(
				iter.GetIterationItems.Count == 1,
				"Count: expected {0}, got {1}",
				new object[] { 1, iter.GetIterationItems.Count });
			Assert.True(iter.TotalIterationCount == 11,
				"Count: expected {0}, got {1}",
				new object[] { 10, iter.TotalIterationCount });
		}

		[Test, Description("IterationItem (NumberRange:Inclusive, Negative) is accurate")]
		public void Iteration_MultiEntry_areCountsOK()
		{
			Dictionary<string, string[]> IterationSets = new Dictionary<string, string[]>();
			IterationSets.Add("List", new string[] { "A", "B", "C" });
			IterationSets.Add("Numbers01", new string[] { "10", "9", "8", "7", "6", "5", "4", "3", "2", "1", "0" });
			IterationSets.Add("Numbers02", new string[] { "250", "255", "260", "265", "270", "275", "280" });

			Iteration iter = new Iteration();

			iter.AddListItems("List", new List<string>(IterationSets["List"]));
			Assert.AreEqual(iter.GetIterationItems.Count, 1);
			Assert.AreEqual(iter.TotalIterationCount, IterationSets["List"].LongLength);

			iter.AddNumberRange("Numbers01", 10, -1, 0, Iteration.EndValueEval.Inclusive);
			Assert.AreEqual(iter.GetIterationItems.Count, 2);
			Assert.AreEqual(
				iter.TotalIterationCount,
				IterationSets["List"].LongLength * IterationSets["Numbers01"].LongLength
				);

			iter.AddNumberSequence("Numbers02", 250, 5, 7);
			Assert.AreEqual(iter.GetIterationItems.Count, 3);
			Assert.AreEqual(
				iter.TotalIterationCount,
				IterationSets["List"].LongLength * IterationSets["Numbers01"].LongLength * IterationSets["Numbers02"].LongLength
				);

			Int64 masterIndex = 0;
			int lengthList = IterationSets["List"].Length;
			int lengthNumbers01 = IterationSets["Numbers01"].Length;
			int lengthNumbers02 = IterationSets["Numbers02"].Length;
			// loop order: outermost is first added, to innermost is last item added.
			for (int indexList = 0; indexList < lengthList; indexList++) //
			{
				for (int indexNumbers01 = 0; indexNumbers01 < lengthNumbers01; indexNumbers01++)
				{
					for (int indexNumbers02 = 0; indexNumbers02 < lengthNumbers02; indexNumbers02++)
					{
						Dictionary<string, string> thisIndexIteration = iter.GetIterationValueSet(masterIndex);
						foreach (string listKey in IterationSets.Keys)
						{
							int listPosition = listKey == "List" ? indexList : (listKey == "Numbers01" ? indexNumbers01 : indexNumbers02);
							Assert.AreEqual(
								thisIndexIteration[listKey],
								IterationSets[listKey][listPosition],
								"Failure for masterIndex @ {0} for {1}: expected: \"{2}\"; got \"{3}\"",
								new object[] {
									masterIndex,
									listKey,
									IterationSets[listKey][listPosition],
									thisIndexIteration[listKey]
								}
							);
						}
						masterIndex++;
					}
				}
			}
			Assert.AreEqual(masterIndex, iter.TotalIterationCount);
		}

		#region Helpers
		private Iteration GetIterationForListItems()
		{
			Iteration result = new Iteration();

			return result;
		}
		#endregion
	}
}
