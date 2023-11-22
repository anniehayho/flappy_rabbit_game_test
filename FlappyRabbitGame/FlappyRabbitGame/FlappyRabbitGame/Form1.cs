using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyRabbitGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int gravity = 10;
        int speed = 25;
        int score = 0;

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                timer1.Start();
            }
        }

        Random rnd = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            rabbit.Top += gravity;
            pipedown.Left -= speed;
            pipeup.Left -= speed;
            lbScore.Text = $"Score: {score}";
            //adding score
            if (pipedown.Left < -140)
            {
                pipedown.Left = rnd.Next(100, 600);
                score++;
            }
            if (pipeup.Left < -140)
            {
                pipeup.Left = rnd.Next(300, 700);
                score++;
            }
            if (rabbit.Bounds.IntersectsWith(pipedown.Bounds) || rabbit.Bounds.IntersectsWith(pipeup.Bounds) || rabbit.Bounds.IntersectsWith(ground.Bounds))
            {
                timer1.Stop();
                lbScore.Text += " Game over!!!";
            }
            if (score > 10)
            {
                speed += 5;
            }
        }
    }
}
