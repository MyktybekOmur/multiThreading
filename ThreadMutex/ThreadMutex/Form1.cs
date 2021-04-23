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

namespace ThreadMutex
{
    public partial class Form1 : Form
    {
        Mutex mut;
        public Form1()
        {
            InitializeComponent();
            mut = new Mutex();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
            Thread thr1 = new Thread(Prog1);
            Thread thr2 = new Thread(Prog2);
            Thread thr3 = new Thread(Prog3);

            thr1.Start();
            thr2.Start();
            thr3.Start();

        }
        public void Prog1()
        {
            mut.WaitOne();
            try
            {
                while(progressBar1.Value < 100)
                        {
                            progressBar1.Value += 1;
                            textBox1.Text += "X";
                            Thread.Sleep(30);
                        }
            }
            finally
            {
                mut.ReleaseMutex();
            }
            
        }
        public void Prog2()
        {
            mut.WaitOne();
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
                mut.ReleaseMutex();
            }
        }
        public void Prog3()
        {
            mut.WaitOne();
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
                mut.ReleaseMutex();
            }
           
        }
    }
}
