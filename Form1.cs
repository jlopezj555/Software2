using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Round_robin_SO
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int pro1, pro2, pro3, pro4, pro5, pro6, pro7, pro8, pro9, pro10;
        int valACT;
        int totalProg;

        List<ProgressBar> procesos = new List<ProgressBar>();
        public Form1()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pro1 = rnd.Next(5, 10);
            label1.Text = "Progreso 1 = " + pro1;
            pro2 = rnd.Next(5, 10);
            label2.Text = "Progreso 2 = " + pro2;
            pro3 = rnd.Next(5, 10);
            label3.Text = "Progreso 3 = " + pro3;
            pro4 = rnd.Next(5, 10);
            label4.Text = "Progreso 4 = " + pro4;
            pro5 = rnd.Next(5, 10);
            label5.Text = "Progreso 5 = " + pro5;
            pro6 = rnd.Next(5, 10);
            label6.Text = "Progreso 6 = " + pro6;
            pro7 = rnd.Next(5, 10);
            label7.Text = "Progreso 7 = " + pro7;
            pro8 = rnd.Next(5, 10);
            label8.Text = "Progreso 8 = " + pro8;
            pro9 = rnd.Next(5, 10);
            label9.Text = "Progreso 9 = " + pro9;
            pro10 = rnd.Next(5, 10);
            label10.Text = "Progreso 10 = " + pro10;

            totalProg = pro1 + pro2 + pro3 + pro4 + pro5 + pro6 + pro7 + pro8 + pro9 + pro10;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.ForeColor = Color.Green;
            progressBar2.ForeColor = Color.Green;
            progressBar3.ForeColor = Color.Green;
            progressBar4.ForeColor = Color.Green;
            progressBar5.ForeColor = Color.Green;
            progressBar6.ForeColor = Color.Green;
            progressBar7.ForeColor = Color.Green;
            progressBar8.ForeColor = Color.Green;
            progressBar9.ForeColor = Color.Green;
            progressFinal.ForeColor = Color.Green;
            progressBar11.ForeColor = Color.Green;

            int aux = 0;
            progressBar1.Maximum = pro1;
            progressBar2.Maximum = pro2;
            progressBar3.Maximum = pro3;
            progressBar4.Maximum = pro4;
            progressBar5.Maximum = pro5;
            progressBar6.Maximum = pro6;
            progressBar7.Maximum = pro7;
            progressBar8.Maximum = pro8;
            progressBar9.Maximum = pro9;
            progressBar11.Maximum = pro10;
            progressFinal.Maximum = totalProg;

            procesos.Add(progressBar1);
            procesos.Add(progressBar2);
            procesos.Add(progressBar3);
            procesos.Add(progressBar4);
            procesos.Add(progressBar5);
            procesos.Add(progressBar6);
            procesos.Add(progressBar7);
            procesos.Add(progressBar8);
            procesos.Add(progressBar9);
            procesos.Add(progressBar11);

            foreach (ProgressBar pro in procesos)
            {
                int quantum = rnd.Next(1, 4);
                label12.Text = "Quantum = " + quantum.ToString();

                aux = 0;
                do
                {
                    aux += quantum;
                    if (aux >= pro.Maximum)
                    {
                        aux = pro.Maximum;
                        pro.ForeColor = Color.Aqua;
                        valACT += aux;
                        progressFinal.Value = valACT;
                        if (progressFinal.Value == progressFinal.Maximum)
                        {
                            progressFinal.ForeColor = Color.Blue;
                        }
                        pro.Value = aux;
                        Thread.Sleep(1000);
                        Application.DoEvents();

                    }
                } while (aux < pro.Maximum);
            }

        }

    }

    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr para1);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }



    }
}