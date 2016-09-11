using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BOG.Framework;
using NUnit.Framework;

namespace BOG.Framework
{
    [TestFixture]
    public class SettingsDictionaryTest
    {
        SettingsDictionary sd;
        string persist_file1 = Path.Combine(Path.GetTempPath(), "TestSettings1.xml");
        string persist_file2 = Path.Combine(Path.GetTempPath(), "TestSettings2.xml");
        string persist_file3 = Path.Combine(Path.GetTempPath(), "TestSettings3.xml");
        string persist_file4 = Path.Combine(Path.GetTempPath(), "TestSettings4.xml");

        [Test, Description ("Create a new object, default instantiation method")]
        public void Instantiate1()
        {
            sd = new SettingsDictionary();
			Assert.IsNotNull(sd);
        }

        [Test, Description("Create Test Settings, save in #1")]
        public void LoadTestData1()
        {
            sd = new SettingsDictionary();
            sd.SetSetting("Key1", "Things I don't like");
            sd.SetSetting("Key2", "another thing");
            sd.ConfigurationFile = persist_file1;
            sd.SaveSettings();
			Assert.That(sd.GetKeys().Length == 2);
        }

        [Test, Description("Create Test Settings, save in #2")]
        public void LoadTestData2()
        {
            sd = new SettingsDictionary();
            sd.SetSetting("Key1", "Things I really don't like");
            sd.SetSetting("Key3", "yet another thing");
            sd.ConfigurationFile = persist_file2;
            sd.SaveSettings();
			Assert.That(sd.GetKeys().Length == 2);
		}

		[Test, Description("Merge Settings 1 (precedence) and 2, save to 3")]
        public void MergeTestData3()
        {
            SettingsDictionary sd1 = new SettingsDictionary(persist_file2);
            sd1.LoadSettings();
            sd = new SettingsDictionary(persist_file1);
            sd.LoadSettings();
            sd.MergeSettings(sd1, false);
            sd.ConfigurationFile = persist_file3;
            sd.SaveSettings();
			Assert.That(sd.GetKeys().Length == 3);
		}

		[Test, Description("Merge Settings 1 and 2 (precedence), save to 4")]
        public void MergeTestData4()
        {
            SettingsDictionary sd1 = new SettingsDictionary(persist_file2);
            sd1.LoadSettings();
            sd = new SettingsDictionary(persist_file1);
            sd.LoadSettings();
            sd.MergeSettings(sd1, true);
            sd.ConfigurationFile = persist_file4;
            sd.SaveSettings();
			Assert.That(sd.GetKeys().Length == 3);
		}
	}
}
