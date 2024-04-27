using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace MaturaXD
{
    public partial class Skola : Form
    {
        
        public Skola()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(imeSkole.Text == "" || nazivTemplate.Text == "")
            {
                MessageBox.Show("Niste dobro uneli podatke", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (vrstaM.Text == "" || jezikM.Text == "" || prviP.Text == "" || treciP.Text == "" || drugiP.Text == "")
            {
                MessageBox.Show("Niste dobro uneli podatke", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Templates");
            string fileName = "Temp." + nazivTemplate.Text + ".txt";
            string filePath = Path.Combine(folderPath, fileName);

            StreamWriter save = new StreamWriter(filePath, true);

            save.WriteLine(imeSkole.Text);
            save.WriteLine(vrstaM.SelectedIndex);
            save.WriteLine(jezikM.SelectedIndex);
            save.WriteLine(prviP.SelectedIndex);
            save.WriteLine(drugiP.SelectedIndex);
            save.WriteLine(treciP.SelectedIndex);

            save.Close();

            nazivTemplate.Text = "";

            MessageBox.Show("Template uspesno napravljen","Alfanum demo" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Skola_Load(object sender, EventArgs e)
        {

        }
    }
}
