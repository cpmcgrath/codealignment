using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CMcG.CodeAlignment.Business
{
    [Serializable]
    public class KeyShortcut
    {
        public Key    Value          { get; set; }
        public string Alignment      { get; set; }
        public string Language       { get; set; }
        public bool   AlignFromCaret { get; set; }
        public bool   UseRegex       { get; set; }
        public bool   AddSpace       { get; set; }

        public static KeyShortcut[] Get(string xml)
        {
            var serializer = new XmlSerializer(typeof(KeyShortcut[]));
            var reader     = new StringReader(xml);
            return (KeyShortcut[])serializer.Deserialize(reader);
        }

        public static string Serialize(KeyShortcut[] shortcuts)
        {
            var serializer = new XmlSerializer(shortcuts.GetType());
            var writer     = new StringWriter();
            serializer.Serialize(writer, shortcuts);
            return writer.ToString();
        }
    }
}