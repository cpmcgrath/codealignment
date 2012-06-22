using System;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Process = System.Diagnostics.Process;

namespace CMcG.CodeAlignment
{
    public partial class FormAbout : Controls.BaseForm
    {
        public FormAbout()
        {
            InitializeComponent();
            var data = new AboutData();
            Text                = string.Format("About {0}",   data.AssemblyTitle);
            labelVersion  .Text = string.Format("Version {0}", data.AssemblyVersion);
            labelCopyright.Text = data.AssemblyCopyright;
            if (AboutData.Image != null)
                ctlLogo.Image = AboutData.Image;
        }

        void GoToWebsite(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.codealignment.com");
        }

        void Donate(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?hosted_button_id=AZZSHWMQ946V2&cmd=_s-xclick");
        }
    }

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