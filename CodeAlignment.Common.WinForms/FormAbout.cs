using System;
using System.Linq;
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
}