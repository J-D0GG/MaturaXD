using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace MaturaXD
{
    public partial class poc : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public poc()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste spremni za pakao?", "قد يرشدك الرب خلال النار", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!Directory.Exists("Ucenici"))
                {
                    Directory.CreateDirectory("Ucenici");
                }

                if (!Directory.Exists("Templates"))
                {
                    Directory.CreateDirectory("Templates");
                }

                Ucenici ucenici = new Ucenici();
                ucenici.Show();
                this.Hide();
                player.controls.stop();
            }
            else if (dialogResult == DialogResult.No)
            {
                Process.Start("draganVirus.exe");
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/s /t 0");
        }

        private void poc_Load(object sender, EventArgs e)
        {
            player.URL = "matrix.mp3";
            player.controls.play();
            player.settings.setMode("loop", true);

        }
    }
}
