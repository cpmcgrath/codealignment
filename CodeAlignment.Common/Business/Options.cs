using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace CMcG.CodeAlignment.Business
{
    using Settings = Properties.Settings;

    public class Options
    {
        Settings m_settings = Settings.Default;
        public Options()
        {
            Shortcuts          = KeyShortcut.Get(m_settings.Shortcuts).ToList();
            XmlTypes           = m_settings.XmlTypes.Cast<string>().ToArray();
            ScopeSelectorRegex = m_settings.ScopeSelectorRegex;
        }

        public List<KeyShortcut> Shortcuts          { get; set; }
        public string[]          XmlTypes           { get; private set; }
        public string            ScopeSelectorRegex { get; set; }

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
            var original       = (StringCollection)Settings.Default.Properties["XmlTypes"].DefaultValue;
            XmlTypes           = original.Cast<string>().ToArray();
            ScopeSelectorRegex = (string)Settings.Default.Properties["ScopeSelectorRegex"].DefaultValue;
        }

        public void Save()
        {
            m_settings.Shortcuts = KeyShortcut.Serialize(Shortcuts.ToArray());
            m_settings.XmlTypes.Clear();
            m_settings.XmlTypes.AddRange(XmlTypes);
            m_settings.ScopeSelectorRegex = ScopeSelectorRegex;
            m_settings.Save();
        }
    }
}