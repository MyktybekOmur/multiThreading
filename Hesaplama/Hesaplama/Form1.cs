using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Hesaplama
{
    public partial class Form1 : Form
    {
        Dortislem.Hesapla deneme;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(deneme.Topla(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)));
        }
        private void Form_load(object sender, EventArgs e)
        {
            deneme = new Dortislem.Hesapla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(deneme.Cikar(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(deneme.Carp(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(deneme.Bol(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
            Thread thr1 = new Thread(new ThreadStart(Prog1));
            Thread thr2 = new Thread(new ThreadStart(Prog2));
            Thread thr3 = new Thread(new ThreadStart(Prog3));

            thr1.Start();
            thr2.Start();
            thr3.Start();
        }
        public void Prog1()
        {
            while(progressBar1.Value < 100)
            {
                progressBar1.Value += 1;
                textBox4.Text += 'X';
                Thread.Sleep(30);
            }
        }
        public void Prog2()
        {
            while (progressBar2.Value < 100)
            {
                progressBar2.Value += 1;
                textBox4.Text += 'Y';
                Thread.Sleep(40);
            }
        }
        public void Prog3()
        {
            while (progressBar3.Value < 100)
            {
                progressBar3.Value += 1;
                textBox4.Text += 'Z';
                Thread.Sleep(50);
            }
        }
    }
}
