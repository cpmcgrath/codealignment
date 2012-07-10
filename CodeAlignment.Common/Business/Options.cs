using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace CMcG.CodeAlignment.Business
{
    using Settings = Properties.Settings;
    using System.IO;
    using System.Xml.Serialization;
    using System.Text.RegularExpressions;

    public class Options
    {
        Settings m_settings = Settings.Default;
        public Options()
        {
            Shortcuts               = KeyShortcut.Get(m_settings.Shortcuts).ToList();
            XmlTypes                = m_settings.XmlTypes.Cast<string>().ToArray();
            ScopeSelectorLineValues = m_settings.ScopeSelectorLineValues;
            ScopeSelectorLineEnds   = m_settings.ScopeSelectorLineEnds;
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
            var xml = (string)Settings.Default.Properties["Shortcuts"].DefaultValue;
            Shortcuts = KeyShortcut.Get(xml).ToList();
        }

        public void ResetSelectorTypes()
        {
            var serializer          = new XmlSerializer(typeof(string[]));
            var xml                 = (string)Settings.Default.Properties["XmlTypes"].DefaultValue;
            XmlTypes                = (string[])serializer.Deserialize(new StringReader(xml));
            ScopeSelectorLineValues = (string)Settings.Default.Properties["ScopeSelectorLineValues"].DefaultValue;
            ScopeSelectorLineEnds   = (string)Settings.Default.Properties["ScopeSelectorLineEnds"]  .DefaultValue;
        }

        public void Save()
        {
            m_settings.Shortcuts = KeyShortcut.Serialize(Shortcuts.ToArray());
            m_settings.XmlTypes.Clear();
            m_settings.XmlTypes.AddRange(XmlTypes);
            m_settings.ScopeSelectorLineValues = ScopeSelectorLineValues;
            m_settings.ScopeSelectorLineEnds   = ScopeSelectorLineEnds;
            m_settings.Save();
        }
    }
}