using System;
using System.Linq;
using System.Windows.Forms;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment.Options
{
    public class KeyLookup
    {
        public KeyLookup(Key key)
        {
            Value       = key;
            Description = key >= Key.D0 && key <= Key.D9 ? key.ToString().Substring(1)
                        : key == Key.OpenBrackets        ? "Open Brackets"
                        : key == Key.CloseBrackets       ? "Close Brackets"
                        : key == Key.EqualsPlus          ? "Equals Plus"
                                                         : key.ToString();
        }

        public Key    Value       { get; set; }
        public string Description { get; set; }

        public static KeyLookup[] GetKeys()
        {
            var keys = Enum.GetValues(typeof(Key)).Cast<Key>();
            return keys.Select(x => new KeyLookup(x)).ToArray();
        }
    }
}