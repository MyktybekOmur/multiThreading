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

namespace TreadSemaphore
{
    public partial class Form1 : Form
    {
        Semaphore sema;
        public Form1()
        {
            InitializeComponent();
            sema = new Semaphore(2,4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
            Thread thr1 = new Thread(Prog1);
            Thread thr2 = new Thread(Prog2);
            Thread thr3 = new Thread(Prog3);
            Thread thr4 = new Thread(Prog4);

            thr1.Start();
            thr2.Start();
            thr3.Start();
            thr4.Start();

        }
        public void Prog1()
        {
            sema.WaitOne();
            try
            {
                while (progressBar1.Value < 100)
                {
                    progressBar1.Value += 1;
                    textBox1.Text += "X";
                    Thread.Sleep(30);
                }
            }
            finally
            {
                sema.Release();
            }

        }
        public void Prog2()
        {
            sema.WaitOne();
            try
            {
                while (progressBar2.Value < 100)
                {
                    progressBar2.Value += 1;
                    textBox1.Text += "Y";
                    Thread.Sleep(50);
                }
            }
            finally
            {
                sema.Release();
            }
        }
        public void Prog3()
        {
            sema.WaitOne();
            try
            {
                while (progressBar3.Value < 100)
                {
                    progressBar3.Value += 1;
                    textBox1.Text += "Z";
                    Thread.Sleep(60);
                }
            }
            finally
            {
                sema.Release();
            }

        }
        public void Prog4()
        {
            sema.WaitOne();
            try
            {
                while (progressBar4.Value < 100)
                {
                    progressBar4.Value += 1;
                    textBox1.Text += "R";
                    Thread.Sleep(70);
                }
            }
            finally
            {
                sema.Release();
            }

        }
    }

}
