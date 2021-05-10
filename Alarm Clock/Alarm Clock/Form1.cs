using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm_Clock
{
    public partial class Form1 : Form
    {
        Boolean activate = false;
        Boolean AlarmActive = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("h:mm tt");
            DateTime currenttime = DateTime.Now;
            DateTime usertime = dateTimePicker1.Value;
          
            if (currenttime.Hour  == usertime.Hour && currenttime.Minute == usertime.Minute)
            {
                SoundPlayer alarm = new SoundPlayer();
                try
                {
                    if (activate == true)
                    {
                        alarm.SoundLocation = @"\alarm.wav";
                        alarm.Play();
                        System.Threading.Thread.Sleep(1000);
                        AlarmActive = true;
                        btnSnooze.Enabled = true;
                    }
                    else
                    {
                        alarm.Stop();
                        AlarmActive = false;
                        btnSnooze.Enabled = false;
                    }
                    
                    
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (activate == true)
            {
                btnActivate.Text = "Activate";
                activate = false;
                btnActivate.BackColor = Color.Green;
            }
            else
            {
                btnActivate.Text = "Deactivate";
                activate = true;
                btnActivate.BackColor = Color.Red;
            }
        }


        private void btnSnooze_Click(object sender, EventArgs e)
        {
           if (AlarmActive == true)
            {
                dateTimePicker1.Value = DateTime.Now.AddMinutes(10);
                btnSnooze.Enabled = false;
            }
        }
    }
}
