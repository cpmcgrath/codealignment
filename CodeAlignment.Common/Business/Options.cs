using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Configuration;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CMcG.CodeAlignment.Business
{
    using Settings = Properties.Settings;
    
    public class Options : INotifyPropertyChanged
    {
        Settings m_settings = Settings.Default;
        public Options()
        {
            Reload();
        }

        void Reload()
        {
            Shortcuts               = KeyShortcut.Get(m_settings.Shortcuts).ToList();
            XmlTypes                = m_settings.XmlTypes.Cast<string>().ToArray();
            ScopeSelectorLineValues = m_settings.ScopeSelectorLineValues;
            ScopeSelectorLineEnds   = m_settings.ScopeSelectorLineEnds;
            UseIdeTabSettings       = m_settings.UseIdeTabSettings;
        }

        public List<KeyShortcut> Shortcuts { get; set; }
        public string[]          XmlTypes  { get; private set; }

        public string ScopeSelectorRegex
        {
            get
            {
                var values = ToOrRegex(ScopeSelectorLineValues, @"^\s*({0}|)\s*$");
                var ends   = ToOrRegex(ScopeSelectorLineEnds,   @"({0})\s*$");

                return ends == null ? values : string.Format("({0}|{1})", values, ends);
            }
        }

        string ToOrRegex(string input, string format)
        {
            var items = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                             .Select(x => Regex.Escape(x));

            return items.Any() ? string.Format(format, items.Aggregate("|")) : null;
        }

        public string ScopeSelectorLineValues { get; set; }
        public string ScopeSelectorLineEnds   { get; set; }
        public bool   UseIdeTabSettings       { get; set; }

        public string XmlTypesString
        {
            get { return XmlTypes.Aggregate("\r\n"); }
            set
            {
                XmlTypes = value.Split('\n')
                                .Select(x => x.Trim().ToLower()).ToArray();
            }
        }

        public KeyShortcut GetShortcut(Key key, string language = null)
        {
            return Shortcuts.Where(x => x.Value == key
                                     && (x.Language == null || x.Language == language))
                            .OrderBy(x => x.Language == language).FirstOrDefault();
        }

        public void ResetShortcuts()
        {
            var xml   = (string)Settings.Default.Properties["Shortcuts"].DefaultValue;
            Shortcuts = KeyShortcut.Get(xml).ToList();
            FirePropertyChanged("Shortcuts");
        }

        public void ResetSelectorTypes()
        {
            var serializer          = new XmlSerializer(typeof(string[]));
            var xml                 = (string)Settings.Default.Properties["XmlTypes"].DefaultValue;
            XmlTypes                = (string[])serializer.Deserialize(new StringReader(xml));
            ScopeSelectorLineValues = (string)Settings.Default.Properties["ScopeSelectorLineValues"].DefaultValue;
            ScopeSelectorLineEnds   = (string)Settings.Default.Properties["ScopeSelectorLineEnds"]  .DefaultValue;
            FirePropertyChanged("XmlTypes", "ScopeSelectorLineValues", "ScopeSelectorLineEnds");
        }

        public void Save()
        {
            m_settings.Shortcuts = KeyShortcut.Serialize(Shortcuts.ToArray());
            m_settings.XmlTypes.Clear();
            m_settings.XmlTypes.AddRange(XmlTypes);
            m_settings.ScopeSelectorLineValues = ScopeSelectorLineValues;
            m_settings.ScopeSelectorLineEnds   = ScopeSelectorLineEnds;
            m_settings.UseIdeTabSettings       = UseIdeTabSettings;
            m_settings.Save();
        }

        public void SaveAs(string filename)
        {
            var node = new XElement("Settings");

            foreach (SettingsPropertyValue prop in m_settings.PropertyValues)
            {
                if (!prop.UsingDefaultValue)
                    node.Add(new XElement(prop.Name) { Value = (string)prop.SerializedValue });
            }

            node.Save(filename);
        }

        public void LoadFrom(string filename)
        {
            var node = XElement.Load(filename);
            var settings = from setting in node.Elements()
                           select new { Key = setting.Name.ToString(), Value = setting.Value };

            foreach (var setting in settings)
            {
                var prop = m_settings.PropertyValues[setting.Key];
                prop.SerializedValue = setting.Value;
                prop.Deserialized    = false;
            }

            m_settings.Save();
            Reload();
        }

        void FirePropertyChanged(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}