using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bubble()
        {
            Random r = new Random();
            int i;
            foreach (Control j in this.Controls)
            {
                if (j is PictureBox && j.Tag == "bubble")
                {
                    j.Top -= 5;
                    if (j.Top < 0)
                    {
                        i = r.Next(80, 1000);
                        j.Location = new Point(i, 900);
                    }
                }

            }
        }
        int score;
        private void fishmove()
        { 
                Random r = new Random();
            int i;
            foreach (Control j in this.Controls)
            {
                if (j is PictureBox && j.Tag == "fish")
                {
                    j.Left -= 2;
                    if (j.Left < 0)
                    {
                        i = r.Next(60, 370);
                        j.Location = new Point(1100, i);
                    }
                    if (play.Bounds.IntersectsWith(j.Bounds))
                    {
                        i = r.Next(60, 370);
                        j.Location = new Point(1100, i);
                        score++;
                        label1.Text = score.ToString();
                        play.Size += new Size(2, 2);
                        progressBar1.Value += 5;
                        if (progressBar1.Value > 99)
                        {
                            label3.Visible = true;
                            timer1.Stop();
                            label3.Text ="مبروك لقد كسبت";
                            play.Hide();
                        }
                    }
                }

            }
        }
        private void enemymove()
        {
            Random r = new Random();
            int i;
            foreach (Control j in this.Controls)
            {
                if (j is PictureBox && j.Tag == "enemy")
                {
                    j.Left -= 2;
                    if (j.Left < 0)
                    {
                        i = r.Next(60, 370);
                        j.Location = new Point(1100, i);
                    }
                    if (play.Bounds.IntersectsWith(j.Bounds))
                    {
                        if (play.Size == new Size(60, 40))
                        {
                            label2.Visible = true;
                            timer1.Stop();
                            label2.Text = "لقد خسرت انتهت اللعبة";
                            play.Hide();
                        }
                        else { play.Size = new Size(60, 40); j.Left = 700; }

                        
                    }

                }

            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (play.Top > 50) { play.Top -= 10; }
                    break;

                case Keys.Down:
                    if (play.Top < 470) { play.Top += 10; }
                    break;

                case Keys.Right:
                    if (play.Right < 1085) { play.Left += 10; }
                    play.Image = Properties.Resources.playr1;
                    break;

                case Keys.Left:
                    if (play.Left > 0) { play.Left -= 10; }
                    play.Image = Properties.Resources.playr2;
                    break;
            }

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            play.Top += 1;
            bubble();
            fishmove();
            enemymove();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}

