using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace les_batonnets_1._0
{
    public partial class Form1 : Form
    {
        new int GlaceRestante = 10;
        new int GlaceProvisoire = 10;
        new bool Jouer = false;
        new int GlaceJoueParBot = 0;
        new bool BotJouer = false;

        new bool drag = false;
        new Point point1 = new Point(0, 0);

        PictureBox[] glace = new PictureBox[10];

        public Form1()
        {
            InitializeComponent();

            glace[0] = pictureBox1;
            glace[1] = pictureBox2;
            glace[2] = pictureBox3;
            glace[3] = pictureBox4;
            glace[4] = pictureBox5;
            glace[5] = pictureBox6;
            glace[6] = pictureBox7;
            glace[7] = pictureBox8;
            glace[8] = pictureBox9;
            glace[9] = pictureBox10;
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlaceProvisoire = GlaceRestante - 1;
            textBox1.Text = ("Vous allez manger 1 glace");
            Jouer = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GlaceProvisoire = GlaceRestante - 2;
            textBox1.Text = ("Vous allez manger 2 glaces");
            Jouer = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlaceProvisoire = GlaceRestante - 3;
            textBox1.Text = ("Vous allez manger 3 glaces");
            Jouer = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Jouer == true)
            {
                GlaceRestante = GlaceProvisoire;
                
                CacheGlace();
                for (int i = 0; i < GlaceRestante; i++)
                {
                    glace[i].Visible = true;
                }

                textBox1.Clear();

                if (GlaceRestante == 0)
                {
                    textBox4.Text = ("Bravo! Vous avez gagné");
                }
                else
                {
                    System.Threading.Thread.Sleep(200);
                    GlaceJoueParBot = 3;
                    if (GlaceRestante - GlaceJoueParBot - 3 >= 1 || GlaceRestante - GlaceJoueParBot == 0)
                    {
                        GlaceRestante -= 3;
                        BotJouer = true;
                    }
                    else
                    {
                        GlaceJoueParBot = 2;
                    }
                    if ((GlaceRestante - GlaceJoueParBot - 3 >= 1) && BotJouer == false || GlaceRestante - GlaceJoueParBot == 0 && BotJouer == false)
                    {
                        GlaceRestante -= 2;
                        BotJouer = true;
                    }
                    if (BotJouer == false)
                    {
                        GlaceRestante -= 1;
                    }

                    CacheGlace();

                    if (GlaceRestante == 0)
                    {
                        textBox4.Text = ("Dommage, vous avez perdu");
                    }
                    else
                    {
                        textBox4.Text = ("Il reste : " + GlaceRestante.ToString() + " glaces");
                        BotJouer = false;

                        for (int i = 0; i < GlaceRestante; i++)
                        {
                            glace[i].Visible = true;
                        }
                    }
                }
            }
            else
            {
                textBox4.Text = ("Vous devez d'abord joué");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(45, 140, 200);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void CacheGlace()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            point1 = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.point1.X, p.Y - this.point1.Y);
            }
        }
    }
}
