using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace MaturaXD
{
    public partial class Ucenici : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Ucenici()
        {
            InitializeComponent();
            label10.Parent = pictureBox1;
            player.URL = "gta 4.mp3";
            player.controls.play();
            player.settings.setMode("loop", true);
        }

        private void Ucenici_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (imeSkole.Text != "" && vrstaM.Text != "" && jezikM.Text != "" && prviP.Text != "" && drugiP.Text != "" && treciP.Text != "" && imeUcenika.Text != "" && prezimeUcenika.Text != "" && odeljenje.Text != "")
            {
                //string folderPath = Directory.GetCurrentDirectory();
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Ucenici");
                string fileName =imeUcenika.Text + prezimeUcenika.Text + "IV" + odeljenje.Text + ".txt";
                string filePath = Path.Combine(folderPath, fileName);
                if(File.Exists(filePath) == true)
                {
                    File.Delete(filePath);
                }

                StreamWriter save = new StreamWriter(filePath, true);

                save.WriteLine(imeUcenika.Text);
                save.WriteLine(prezimeUcenika.Text);
                save.WriteLine("IV" + odeljenje.Text);
                save.WriteLine(imeSkole.Text);
                save.WriteLine(vrstaM.SelectedItem);
                save.WriteLine(jezikM.SelectedItem);
                save.WriteLine(prviP.SelectedItem);
                save.WriteLine(drugiP.SelectedItem);
                save.WriteLine(treciP.SelectedItem);

                save.Close();


                MessageBox.Show("Ucenik uspesno unesen", "Alfanum demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Niste dobro uneli podatke","Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void unesiTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "(*.txt)|*.txt";
            fileDialog.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Templates");
            fileDialog.ShowDialog();

            string rez = fileDialog.FileName;

            if(fileDialog.FileName != "")
            {
                StreamReader ucitaj = new StreamReader(rez);

                imeSkole.Text = ucitaj.ReadLine();
                vrstaM.SelectedIndex = Convert.ToInt32(ucitaj.ReadLine());
                jezikM.SelectedIndex = Convert.ToInt32(ucitaj.ReadLine());
                prviP.SelectedIndex = Convert.ToInt32(ucitaj.ReadLine());                drugiP.SelectedIndex = Convert.ToInt32(ucitaj.ReadLine());
                treciP.SelectedIndex = Convert.ToInt32(ucitaj.ReadLine());

                //Remove(ucitaj.ReadLine().Length - 1, 1);

                ucitaj.Close();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Skola skola = new Skola();
            skola.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da zelite da obrisete sve ucenike?", "Upozorenje", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Ucenici");
                string[] filePaths = System.IO.Directory.GetFiles(folderPath, "*.txt");
                foreach (string filePath in filePaths)
                {
                        System.IO.File.Delete(filePath);
                }
            }
        }

        private void ucitajUcenika_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Ucenici");
            fileDialog.Filter = "(*.txt)|*.txt";
            fileDialog.ShowDialog();

            string rez = fileDialog.FileName;

            if (fileDialog.FileName != "")
            {
                StreamReader ucitaj = new StreamReader(rez);

                imeUcenika.Text = ucitaj.ReadLine();
                prezimeUcenika.Text = ucitaj.ReadLine();
                string odeljenj = ucitaj.ReadLine();
                odeljenj = odeljenj.Remove(0, 2);
                odeljenje.Text = Convert.ToString(odeljenj);
                imeSkole.Text = ucitaj.ReadLine();
                vrstaM.Text = ucitaj.ReadLine();
                jezikM.Text = ucitaj.ReadLine();
                prviP.Text = ucitaj.ReadLine();
                drugiP.Text = ucitaj.ReadLine();
                treciP.Text = ucitaj.ReadLine();

                ucitaj.Close();
            }
            

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                File.WriteAllText("rezultat.csv", String.Empty);
                StreamWriter cuvaj = new StreamWriter("rezultat.csv");

                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Ucenici");
                string[] filePaths = System.IO.Directory.GetFiles(folderPath, "*.txt");



                foreach (string filePath in filePaths)
                {
                    StreamReader citaj = new StreamReader(filePath);

                    for (int j = 0; j < 8; j++)
                    {
                        cuvaj.Write(citaj.ReadLine() + ";");
                    }
                    cuvaj.WriteLine(citaj.ReadLine());
                    citaj.Close();
                }
                cuvaj.Close();
            string otvori = Path.Combine(Directory.GetCurrentDirectory(), "rezultat.csv");
            Process.Start(otvori);
        }

        private void Ucenici_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
