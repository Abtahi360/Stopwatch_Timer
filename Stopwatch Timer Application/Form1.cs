using Stopwatch_Timer_Application.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stopwatch_Timer_Application
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
        int hour, minute, second, millisecond;
        List<string> historyList = new List<string>();

        public Form1()
        {
            InitializeComponent();
            timer = new System.Timers.Timer();
            timer.Interval = 10;
            timer.Elapsed += Timer_Elapsed;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer.Stop();
            hour = 0;
            minute = 0;
            second = 0;
            millisecond = 0;
            label2.Text = "00 : 00 : 00 : 00";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string currentTime = label2.Text;
            historyList.Add(currentTime); 
            UpdateHistoryDisplay();

            timer.Stop();
            hour = 0;
            minute = 0;
            second = 0;
            millisecond = 0;
            label2.Text = "00 : 00 : 00 : 00";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private bool isDarkTheme = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (isDarkTheme)
            {
                this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(113)))), ((int)(((byte)(133)))));
                this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                this.label1.ForeColor = System.Drawing.Color.Black;
                this.label3.ForeColor = System.Drawing.Color.Black;
                this.label2.ForeColor = System.Drawing.Color.Black;
                this.listBox1.ForeColor = System.Drawing.Color.Black;
                this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(80)))), ((int)(((byte)(146)))));
                this.Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(80)))), ((int)(((byte)(146)))));
                this.Reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(80)))), ((int)(((byte)(146)))));
                this.Pause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(80)))), ((int)(((byte)(146)))));
            }
            else
            {
                this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
                this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                this.label1.ForeColor = System.Drawing.Color.White;
                this.label3.ForeColor = System.Drawing.Color.White;
                this.label2.ForeColor = System.Drawing.Color.White;
                this.listBox1.ForeColor = System.Drawing.Color.White;
                this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
                this.Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
                this.Reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
                this.Pause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
            }

            isDarkTheme = !isDarkTheme;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            historyList.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                millisecond++;
                if (millisecond == 100)
                {
                    millisecond = 0;
                    second++;
                }
                if (second == 60)
                {
                    second = 0;
                    minute++;
                }
                if (minute == 60)
                {
                    minute = 0;
                    hour++;
                }
                label2.Text = string.Format("{0} : {1} : {2} : {3}",
                    hour.ToString().PadLeft(2, '0'),
                    minute.ToString().PadLeft(2, '0'),
                    second.ToString().PadLeft(2, '0'),
                    millisecond.ToString().PadLeft(2, '0'));
            }));
        }

        private void UpdateHistoryDisplay()
        {
            listBox1.Items.Clear();
            foreach (string entry in historyList)
                listBox1.Items.Add(entry);
        }
    }
}