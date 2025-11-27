using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordMultiTool
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Process.GetProcessesByName("Discord").ToList().ForEach(x => x.Kill());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Process.GetProcessesByName("Telegram").ToList().ForEach(x => x.Kill());
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string cartella= @"C:\Users\" + Environment.UserName + @"\.dmt";
            System.IO.Directory.Delete(cartella, true);

            if (EventLog.SourceExists("DiscordMultiTool"))
            {
                EventLog.Delete("DiscordMultiTool");
            }

            Process.GetCurrentProcess().Kill();
        }
    }
}
