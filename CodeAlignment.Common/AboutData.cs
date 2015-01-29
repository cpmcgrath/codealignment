using System;
using System.Linq;
using System.Drawing;
using System.Reflection;

namespace CMcG.CodeAlignment
{
    public class AboutData
    {
        public static Image Image { get; set; }

        static Assembly s_mainAssembly;
        public static Assembly MainAssembly
        {
            get { return s_mainAssembly ?? Assembly.GetExecutingAssembly(); }
            set { s_mainAssembly = value; }
        }

        public string AssemblyTitle
        {
            get
            {
                var title = GetAttributeProperty<AssemblyTitleAttribute>(x => x.Title);
                return title != string.Empty ? title : "Code alignment";
            }
        }

        public string AssemblyVersion
        {
            get { return MainAssembly.GetName().Version.ToString(); }
        }

        public string AssemblyCopyright
        {
            get { return GetAttributeProperty<AssemblyCopyrightAttribute>(x => x.Copyright); }
        }

        public string GetAttributeProperty<T>(Func<T, string> getProperty) where T : Attribute
        {
            var attribute = (T)MainAssembly.GetCustomAttributes(typeof(T), false).FirstOrDefault();
            return attribute != null ? getProperty.Invoke(attribute) : string.Empty;
        }
    }
}
