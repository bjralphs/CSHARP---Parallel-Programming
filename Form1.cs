
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab07_final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //DECLARE VARIABLES
            string path = Directory.GetCurrentDirectory();
            string username = textBox1.Text;
            int counter = 0;
            string item = path + @"\" + username;
            string count;
            //Verify file exists
            if (System.IO.File.Exists(item) == true)
            {
                //Begin Background thread for reading document
                Thread th = new Thread(t =>
                {
                    foreach (string line in System.IO.File.ReadLines(item))
                    {
                        count = counter.ToString();
                        //Update UI from thread
                        label6.Invoke((MethodInvoker)delegate {
                            // Running on the UI thread
                            label6.Text = count;
                        });
                        counter++;
                    }
                    count = counter.ToString();
                    //Update UI from thread
                    label4.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        label4.Text = count;
                    });
                }
                )
                { IsBackground = true };
                th.Start();
            }
            else
            {
                //ERROR: If program cannot find file
                label4.Text = "Could not find file.";
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

