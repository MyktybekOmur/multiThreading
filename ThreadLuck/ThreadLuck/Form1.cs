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

namespace ThreadLuck
{
    public partial class Form1 : Form
    {
        private object _locker1;
        private object _locker2;
        public Form1()
        {
            InitializeComponent();
            _locker1 = new object();
            _locker2 = new object();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
            Thread thr1 = new Thread(Prog1);
            Thread thr2 = new Thread(Prog2);
            Thread thr3 = new Thread(Prog3);
            Thread thr4 = new Thread(Prog4);
            Thread thr5 = new Thread(Prog5);
            thr1.Start();
            thr2.Start();
            thr3.Start();
            thr4.Start();
            thr5.Start();
        }
        public void Prog1()
        {
            //Monitor.Enter(_locker1);
            //try
            //{
            lock (_locker1)
            {
                 while (progressBar1.Value < 100)
                  {
                        progressBar1.Value += 1;
                        textBox1.Text += "X";
                        Thread.Sleep(30);
                  }
            }

            //}
           /* catch
            {
                Monitor.Exit(_locker1);
            }*/
            
        }
        public void Prog2()
        {
            //Monitor.Enter(_locker1);
            //try
            //{
            lock (_locker1)
            {
                while (progressBar2.Value < 100)
                {
                    progressBar2.Value += 1;
                    textBox1.Text += "Y";
                    Thread.Sleep(50);
                }
            }

            //}
            /* catch
             {
                 Monitor.Exit(_locker1);
             }*/

        }
        public void Prog3()
        {
            //Monitor.Enter(_locker1);
            //try
            //{
            lock (_locker1)
            {
                while (progressBar3.Value < 100)
                {
                    progressBar3.Value += 1;
                    textBox1.Text += "Z";
                    Thread.Sleep(70);
                }
            }

            //}
            /* catch
             {
                 Monitor.Exit(_locker1);
             }*/

        }
        public void Prog4()
        {
            //Monitor.Enter(_locker1);
            //try
            //{
            lock (_locker2)
            {
                while (progressBar4.Value < 100)
                {
                    progressBar4.Value += 1;
                    textBox2.Text += "T";
                    Thread.Sleep(30);
                }
            }

            //}
            /* catch
             {
                 Monitor.Exit(_locker1);
             }*/

        }
        public void Prog5()
        {
            //Monitor.Enter(_locker1);
            //try
            //{
            lock (_locker2)
            {
                while (progressBar5.Value < 100)
                {
                    progressBar5.Value += 1;
                    textBox2.Text += "R";
                    Thread.Sleep(50);
                }
            }

            //}
            /* catch
             {
                 Monitor.Exit(_locker1);
             }*/

        }
    }
}
