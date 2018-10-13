using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm_proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Hour.ToString();
            label2.Text = DateTime.Now.Minute.ToString();
            label6.Text = DateTime.Now.Second.ToString();

            if (comboBox1.Text == label1.Text && comboBox2.Text == label2.Text) 
            {
                timer1.Enabled = false;
                axWindowsMediaPlayer1.URL = textBox1.Text;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.Text=="" && comboBox2.Text=="")
            {
                MessageBox.Show("Alarm kurmak için süre girin. (Dakika ya da saat.)");
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = true;
                timer1.Enabled = true;
            }
                                 
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            button2.Enabled = false;
            for (int i = 0; i < 24; i++)
            {
                comboBox1.Items.Add(i);
            }
            for (int i = 0; i < 60; i++)
            {
                comboBox2.Items.Add(i);
            }
        }
                
        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            timer1.Enabled = true;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = true;
            textBox1.Text = "";

        }
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Alarm Sesi Seçiniz.";
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
            button3.Enabled = false;
        }
    }
}
