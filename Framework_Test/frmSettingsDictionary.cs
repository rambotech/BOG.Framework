using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using BOG.Framework;

namespace BOG.Framework_Test
{
    public partial class frmSettingsDictionary : Form
    {
        string PersistPath = Path.GetTempPath();
        Dictionary<string, SettingsDictionary> sdd = new Dictionary<string, Framework.SettingsDictionary>();
        string lastGridDisplay = string.Empty;

        public frmSettingsDictionary()
        {
            InitializeComponent();
            SettingsDictionary sd = new SettingsDictionary();
            sd.ConfigurationFile = Path.Combine(PersistPath, "TestSettings1.xml");
            sd.SetSetting("key1", "Something");
            sd.SetSetting("key2", "Something Else");
            sdd.Add("Dictionary 1", sd);
            sd = new SettingsDictionary();
            sd.ConfigurationFile = Path.Combine(PersistPath, "TestSettings2.xml");
            sd.SetSetting("key1", "Nothing");
            sd.SetSetting("key3", "Whatever");
            sdd.Add("Dictionary 2", sd);
            sd = new SettingsDictionary();
            sd.ConfigurationFile = Path.Combine(PersistPath, "TestSettings3.xml");
            sd.LoadSettings();
            sd.MergeSettings(sdd["Dictionary 1"], true);
            sd.MergeSettings(sdd["Dictionary 2"], true);
            sdd.Add("Dictionary 3", sd);
            sd = new SettingsDictionary();
            sd.ConfigurationFile = Path.Combine(PersistPath, "TestSettings4.xml");
            sd.LoadSettings();
            sd.MergeSettings(sdd["Dictionary 1"], true);
            sd.MergeSettings(sdd["Dictionary 2"], false);
            sdd.Add("Dictionary 4", sd);

            dgvSettingsDictionary.Columns.Add("Dictionary", "Dictionary");
            dgvSettingsDictionary.Columns.Add("Key", "Key");
            dgvSettingsDictionary.Columns.Add("Value", "Value");

            foreach (string dictKey in sdd.Keys)
            {
                foreach (string key in sdd[dictKey].GetKeys())
                {
                    dgvSettingsDictionary.Rows.Add(new object[] { dictKey, key, sdd[dictKey].GetSetting(key, "{null}") });
                    dgvSettingsDictionary.Rows[dgvSettingsDictionary.Rows.Count - 2].Tag = dictKey;
                }
            }
        }

        private void dgvSettingsDictionary_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string thisGridDisplay = (string)dgvSettingsDictionary.Rows[e.RowIndex].Tag;
            if (lastGridDisplay != thisGridDisplay)
            {
                this.txtXMLview.Text = "Can't find that SettingsDictionary object.. that's weird";
                if (sdd.ContainsKey(thisGridDisplay)) this.txtXMLview.Text = sdd[thisGridDisplay].BuildSettingsXML();
                lastGridDisplay = thisGridDisplay;
            }
        }
    }
}
