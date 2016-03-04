using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace BOG.Framework
{
    /// <summary>
    /// An alternative to using the app.config file format.  A generic dictionary, with save 
    /// and load.  Can also merge settings from another SettingsDictionary instance.
    /// This was designed as a container for storing user settings for an application in the 
    /// %APPDATA% path for windows forms.
    /// </summary>
    public class SettingsDictionary
    {
        private string _ConfigurationPath = string.Empty;
        private string _ConfigurationFile = string.Empty;
        private Dictionary<string, object> AppSettings = new Dictionary<string, object>();
        private bool HasChanges = false;

        /// <summary>
        /// The file where the settings are persisted.
        /// </summary>
        public string ConfigurationFile
        {
            get { return _ConfigurationFile; }
            set
            {
                _ConfigurationFile = value;
                _ConfigurationPath = Path.GetDirectoryName(_ConfigurationFile);
            }
        }

        /// <summary>
        /// Default instantiation
        /// </summary>
        public SettingsDictionary()
        {
        }

        /// <summary>
        /// Specify the configuration file to persist for this instance.
        /// The method does not actually load from the file during instantiation.
        /// </summary>
        /// <param name="configurationFile"></param>
        public SettingsDictionary(string configurationFile)
        {
            ConfigurationFile = configurationFile;
        }

        /// <summary>
        /// Loads the settings from the configuration file.  Existing settings are removed
        /// prior to load.
        /// </summary>
        public void LoadSettings()
        {
            if (File.Exists(_ConfigurationFile))
            {
                AppSettings.Clear();
                XPathDocument doc = new XPathDocument(new FileStream(_ConfigurationFile, FileMode.Open));
                XPathNavigator nav = ((IXPathNavigable)doc).CreateNavigator();
                XPathNodeIterator iter = nav.Select("/settings");
                while (iter.MoveNext())
                {
                    XPathNodeIterator newIter = iter.Current.SelectDescendants(XPathNodeType.Element, false);
                    while (newIter.MoveNext())
                        AppSettings.Add(newIter.Current.Name, newIter.Current.Value);
                }
                HasChanges = false;
            }
        }

        /// <summary>
        /// Merges the settings from the SettingsDictionary instance into SettingsDictionary local to this object.
        /// </summary>
        /// <param name="mergeSource">The SettingsDictionary object to merge</param>
        /// <param name="HasPrecedence">When true, an existing value is overriden by mergeSource; otherwise it is not.</param>
        public void MergeSettings(SettingsDictionary mergeSource, bool HasPrecedence)
        {
            foreach (string key in mergeSource.GetKeys())
            {
                if (!AppSettings.ContainsKey(key))
                {
                    AppSettings.Add(key, mergeSource.GetSetting(key, null));
                    HasChanges = true;
                }
                else
                {
                    if (HasPrecedence)
                    {
                        AppSettings[key] = mergeSource.GetSetting(key, null);
                        HasChanges = true;
                    }
                }
            }
        }

        /// <summary>
        /// Returns the XML document which is used to save the settings.  Normally only used
        /// internally in the class, but is available for non-file storage of the settings.
        /// </summary>
        /// <returns>string containing an XML document</returns>
        public string BuildSettingsXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode rootNode = doc.CreateElement("settings");

            foreach (string s in AppSettings.Keys)
            {
                XmlNode settingNode = doc.CreateElement(s);
                settingNode.AppendChild(doc.CreateTextNode(AppSettings[s].ToString()));
                rootNode.AppendChild(settingNode);
            }
            doc.AppendChild(rootNode);

            return doc.OuterXml;
        }

        /// <summary>
        /// Persist the settings to their file.
        /// </summary>
        public void SaveSettings()
        {
            if (HasChanges)
            {
                if (!Directory.Exists(_ConfigurationPath))
                {
                    Directory.CreateDirectory(_ConfigurationPath);
                }

                File.WriteAllText(_ConfigurationFile, BuildSettingsXML());
                HasChanges = false;
            }
        }

        /// <summary>
        /// Check for an existing key in the settings.
        /// </summary>
        /// <param name="key">the key to search for</param>
        /// <returns>true if it exists; otherwise false.</returns>
        public bool HasSetting(string key)
        {
            return AppSettings.ContainsKey(key);
        }

        /// <summary>
        /// Gets the value for a key, or the defaultValue if the key is not found.
        /// </summary>
        /// <param name="key">the key to find</param>
        /// <param name="defaultValue">the value to return if not found</param>
        /// <returns></returns>
        public object GetSetting(string key, object defaultValue)
        {
            return AppSettings.ContainsKey(key) ? AppSettings[key] : defaultValue;
        }

        /// <summary>
        /// Delete the key/value from the settings.
        /// </summary>
        /// <param name="key">the key to remove</param>
        public void DeleteSetting(string key)
        {
            if (AppSettings.ContainsKey(key))
            {
                AppSettings.Remove(key);
                HasChanges = true;
            }
        }

        /// <summary>
        /// Returns the keys which exist in the settings.
        /// </summary>
        /// <returns>array of strings with the values.</returns>
        public string[] GetKeys()
        {
            List<string> result = new List<string>();
            foreach (string key in AppSettings.Keys) result.Add(key);
            return result.ToArray();
        }

        /// <summary>
        /// Sets the value for the key.
        /// </summary>
        /// <param name="key">the key to store</param>
        /// <param name="value">the value for the key</param>
        public void SetSetting(string key, object value)
        {
            if (AppSettings.ContainsKey(key))
            {
                if (AppSettings[key] != value)
                {
                    AppSettings[key] = value;
                    HasChanges = true;
                }
            }
            else
            {
                AppSettings.Add(key, value);
                HasChanges = true;
            }
        }
    }
}
