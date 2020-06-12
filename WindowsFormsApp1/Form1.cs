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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Process[] runningProcess = Process.GetProcesses();
            for (int i = 0; i < runningProcess.Length; i++)
            {
                if (runningProcess[i].ProcessName == "explorer")
                {
                    isExplorer = true;
                }
            }
            changeText();
        }
        private void changeText()
        {
            if (isExplorer == false)
            {
                label1.Text = "Restaurer son PC";
                button1.Text = "RESTAURER";
                label2.Text = "Ne fermez pas l'application sous peine" +
    "\nde ne pas pouvoir restaurer votre explorateur" +
    "\nde fichiers";
            }
            else
            {
                label1.Text = "Booster son PC";
                button1.Text = "BOOST !";
                label2.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (isExplorer == true)
            {
                Process.Start("taskkill", "/im explorer.exe /f");
                label2.Text = "Ne fermez pas l'application sous peine" +
                    "de ne pas pouvoir restaurer votre explorateur" +
                    "de fichiers";
                isExplorer = false;
            }
            else
            {
                Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"));
                isExplorer = true;
            }
            changeText();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (isExplorer == false)
            {
                if (MessageBox.Show("Êtes vous sur de fermer cette fenêtre ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
        int mouseX = 0, mouseY = 0;
        bool isClicked;

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isClicked = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isClicked = true;
        }
    }
}
