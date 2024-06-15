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
            Assert.That(
                iter.IterationItems.Count == 0,
                $"Count: expected 0, got {iter.IterationItems.Count}");

            iter.AddListItems("ListItem", new List<string>(new string[] { "A", "B", "C" }));
            Assert.That(
                iter.IterationItems.Count == 1,
                $"GetIterationItems.Count: expected {0}, got {iter.IterationItems.Count}");
            Assert.That(
                iter.IterationItemNameExists("ListItem"),
                "iter.IterationItemNameExists(\"ListItem\") failed");
            Assert.That(iter.TotalIterationCount == 3,
                $"Count: expected 3, got {iter.TotalIterationCount}");

            Dictionary<string, string> argSet = iter.GetIterationValueSet(0);
            Assert.That(
                argSet.ContainsKey("ListItem"),
                "argSet.ContainsKey(\"ListItem\") failed");
            Assert.That(
                argSet.Count == 1,
                $"argSet.Count: expected 0, got {argSet.Count}");
            Assert.That(string.Compare(argSet["ListItem"], "A", false) == 0,
                "argSet[\"listitem\"]: expected \"A\", got \"{argSet[\"ListItem\"]}\"");
        }

        [Test, Description("IterationItem (NumberRange:Exclusive, positive) is accurate")]
        public void Iteration_NumberRange_areIterationItemsAndExclusiveCountsPositiveOK()
        {
            Iteration iter = new Iteration();
            Assert.That(
                iter.IterationItems.Count == 0,
                $"Count: expected 0, got {iter.IterationItems.Count}");
            iter.AddNumberRange("NumberRange-01", 0, 1, 10, Iteration.EndValueEval.Exclusive);
            Assert.That(
                iter.IterationItems.Count == 1,
                $"Count: expected 1, got {iter.IterationItems.Count}");
            Assert.That(iter.TotalIterationCount == 10,
                $"Count: expected 10, got {iter.TotalIterationCount}");
        }

        [Test, Description("IterationItem (NumberRange:Inclusive, positive) is accurate")]
        public void Iteration_NumberRange_areIterationItemsAndInclusivePositiveCountsOK()
        {
            Iteration iter = new Iteration();
            Assert.That(
                iter.IterationItems.Count == 0,
                $"Count: expected 0, got {iter.IterationItems.Count}");
            iter.AddNumberRange("NumberRange-01", 0, 1, 10, Iteration.EndValueEval.Inclusive);
            Assert.That(
                iter.IterationItems.Count == 1,
                $"Count: expected 1, got {iter.IterationItems.Count}");
            Assert.That(iter.TotalIterationCount == 11,
                $"Count: expected 10, got {iter.TotalIterationCount}");
        }

        [Test, Description("IterationItem (NumberRange:Exclusive, Negative) is accurate")]
        public void Iteration_NumberRange_areIterationItemsAndExclusiveCountsNegativeOK()
        {
            Iteration iter = new Iteration();
            Assert.That(
                iter.IterationItems.Count == 0,
                $"Count: expected 0, got {iter.IterationItems.Count}");
            iter.AddNumberRange("NumberRange-01", 10, -1, 0, Iteration.EndValueEval.Exclusive);
            Assert.That(
                iter.IterationItems.Count == 1,
                $"Count: expected 1, got {iter.IterationItems.Count}");
            Assert.That(iter.TotalIterationCount == 10,
                $"Count: expected 10, got {iter.IterationItems.Count}");
        }

        [Test, Description("IterationItem (NumberRange:Inclusive, Negative) is accurate")]
        public void Iteration_NumberRange_areIterationItemsAndInclusiveNegativeCountsOK()
        {
            Iteration iter = new Iteration();
            Assert.That(
                iter.IterationItems.Count == 0,
                $"Count: expected 0, got {iter.IterationItems.Count}");
            iter.AddNumberRange("NumberRange-01", 10, -1, 0, Iteration.EndValueEval.Inclusive);
            Assert.That(
                iter.IterationItems.Count == 1,
                $"Count: expected 1, got {iter.IterationItems.Count}");
            Assert.That(iter.TotalIterationCount == 11,
                $"Count: expected 11, got {iter.IterationItems.Count}");
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
            Assert.That(iter.IterationItems.Count == 1);
            Assert.That(iter.TotalIterationCount == IterationSets["List"].LongLength);

            iter.AddNumberRange("Numbers01", 10, -1, 0, Iteration.EndValueEval.Inclusive);
            Assert.That(iter.IterationItems.Count == 2);
            Assert.That(
                iter.TotalIterationCount ==
                IterationSets["List"].LongLength * IterationSets["Numbers01"].LongLength
                );

            iter.AddNumberSequence("Numbers02", 250, 5, 7);
            Assert.That(iter.IterationItems.Count == 3);
            Assert.That(
                iter.TotalIterationCount ==
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
                            Assert.That(thisIndexIteration[listKey] == 
                                IterationSets[listKey][listPosition],
                                string.Format("Failure for masterIndex @ {0} for {1}: expected: \"{2}\"; got \"{3}\"",
                                new object[] {
                                    masterIndex,
                                    listKey,
                                    IterationSets[listKey][listPosition],
                                    thisIndexIteration[listKey]
                                })
                            );
                        }
                        masterIndex++;
                    }
                }
            }
            Assert.That(masterIndex == iter.TotalIterationCount);
        }

        [Test, Description("IterationItem (NumberRange:Inclusive, Negative) is accurate")]
        public void Iteration_GetSet_OK()
        {
            Dictionary<string, string[]> IterationSets = new Dictionary<string, string[]>();
            IterationSets.Add("List", new string[] { "A", "B", "C" });
            IterationSets.Add("Numbers01", new string[] { "10", "9", "8", "7", "6", "5", "4", "3", "2", "1", "0" });
            IterationSets.Add("Numbers02", new string[] { "250", "255", "260", "265", "270", "275", "280" });

            Iteration iter = new Iteration();

            iter.AddListItems("List", new List<string>(IterationSets["List"]));
            iter.AddNumberRange("Numbers01", 10, -1, 0, Iteration.EndValueEval.Inclusive);
            iter.AddNumberSequence("Numbers02", 250, 5, 7);

            string serialized = ObjectXMLSerializer<Iteration>.CreateDocumentFormat(iter);
            Iteration iterCloned = ObjectXMLSerializer<Iteration>.CreateObjectFormat(serialized);

            Assert.That(iter.IterationItems.Count == iterCloned.IterationItems.Count, "Iteration item count mismatch");
            foreach (int key in iter.IterationItems.Keys)
            {
                Assert.That(string.Compare(
                    iter.IterationItems[key].Name,
                    iterCloned.IterationItems[key].Name,
                    false) == 0,
                    "Iteration item name mismatch for key " + key.ToString());
                Assert.That(
                    iter.IterationItems[key].IterationValues.Count ==
                    iterCloned.IterationItems[key].IterationValues.Count,
                    "Iteration item count mismatch for key " + key.ToString());
            }
            Assert.That(iter.TotalIterationCount == iterCloned.TotalIterationCount, "Total count mismatch");
        }
    }
}
