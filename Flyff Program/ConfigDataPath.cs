using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace Flyff_Program
{
    public partial class ConfigDataPath : Form
    {
        Timer t1 = new Timer();
        public ConfigDataPath()
        {
            InitializeComponent();
        }

        private void ConfigDataPath_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            t1.Interval = 10;
            t1.Tick += new EventHandler(fadeIn);
            t1.Start();
            string FilePath = File.ReadAllText(@"Setting.txt");
            FolderPath.Text = ResourceFlyff.Resource.Between(FilePath.ToString(), "FolderPath=", "\r\nIPServer=");
        }

        void fadeIn(object sender, EventArgs e)
        {
            if (Opacity >= 1)
                t1.Stop();
            else
                Opacity += 0.05;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog frm = new FolderBrowserDialog();
            DialogResult result = frm.ShowDialog();
            if(result == DialogResult.OK)
            {
                FolderPath.Text = frm.SelectedPath;
                Environment.SpecialFolder root = frm.RootFolder;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FolderPath.Text != "")
            {
                string FilePath = File.ReadAllText(@"Setting.txt");
                string txtreplace = FilePath.Replace(ResourceFlyff.Resource.Between(FilePath.ToString(), "FolderPath=", "\r\nIPServer="), FolderPath.Text);
                File.WriteAllText(@"Setting.txt", txtreplace);

                MessageBox.Show("Save Complete !", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Can't find any path", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
