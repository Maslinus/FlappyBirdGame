using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace FlappyBird
{

    public partial class Form1 : Form
    {
        Player bird;
        TheWall wall1;
        TheWall wall2;
        TheWall wall3;
        TheWall wall4;
        float gravity;

        SoundPlayer sound = new SoundPlayer(@"D:\данияра папка\С#\semeчkи\3-sem\FlappyBird\1w.wav");
        SoundPlayer sound2 = new SoundPlayer(@"D:\данияра папка\С#\semeчkи\3-sem\FlappyBird\4w.wav");
        SoundPlayer sound3 = new SoundPlayer(@"D:\данияра папка\С#\semeчkи\3-sem\FlappyBird\3w.wav");
        public Form1()
        {

            InitializeComponent();
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(update);
            Init();
            Invalidate();
            TREK();
            
        }

        async void TREK()
        {

            await Task.Run(()=>
            {
                sound3.Play();
            });
        }

        public void Init()
        {
            bird = new Player(200, 200);
            wall1 = new TheWall(500, -100, true);
            wall2 = new TheWall(500, 350);

            wall3 = new TheWall(900, -100, true);
            wall4 = new TheWall(900, 350);

            gravity = 0;
            this.Text = "Flappy Bird Score: 0";
            timer1.Start();
        }

        private void update(object sender, EventArgs e)
            {
                if (bird.y > 600)
                {
                    sound2.PlaySync();
                    TREK();

                    bird.isAlive = false;
                    timer1.Stop();
                    Init();
                }

                if (Collide1(bird, wall1) || Collide1(bird, wall2))
                {
                    bird.isAlive = false;
                    timer1.Stop();
                    Init();
                }

                if (Collide2(bird, wall3) || Collide2(bird, wall4))
                {
                    bird.isAlive = false;
                    timer1.Stop();
                    Init();
                }

                if (bird.gravityValue != 0.1f)
                    bird.gravityValue += 0.005f;
                gravity += bird.gravityValue;
                bird.y += gravity;

                if (bird.isAlive) {
                    MoveWalls();
                }

                Invalidate();
            }


            private bool Collide1(Player bird, TheWall wall1)
            {
                PointF delta = new PointF();
                delta.X = (bird.x + bird.size / 2) - (wall1.x + wall1.sizeX / 2);
                delta.Y = (bird.y + bird.size / 2) - (wall1.y + wall1.sizeY / 2);



                if (Math.Abs(delta.X) <= bird.size / 2 + wall1.sizeX / 2)
                {
                    if (Math.Abs(delta.Y) <= bird.size / 2 + wall1.sizeY / 2)
                    {
                        sound2.PlaySync();
                        TREK();
                        return true;

                    }
                }



                return false;
            }

            private bool Collide2(Player bird, TheWall wall3)
            {
                PointF delta = new PointF();

                delta.X = (bird.x + bird.size / 2) - (wall3.x + wall3.sizeX / 2);
                delta.Y = (bird.y + bird.size / 2) - (wall3.y + wall3.sizeY / 2);

                if (Math.Abs(delta.X) <= bird.size / 2 + wall3.sizeX / 2)
                {
                    if (Math.Abs(delta.Y) <= bird.size / 2 + wall3.sizeY / 2)
                    {
                        sound2.PlaySync();
                        TREK();
                        return true;
                    }
                }


                return false;
            }

            private void CreateNewWall()
            {
            if (bird.score < 5) {
                if (wall1.x < bird.x - 350)
                {
                    Random r = new Random();
                    int y1;
                    y1 = r.Next(-200, 000);
                    wall1 = new TheWall(500, y1, true);
                    wall2 = new TheWall(500, y1 + 400);
                    this.Text = "Flappy Bird Score: " + ++bird.score;
                }

                if (wall3.x < bird.x - 350)
                {
                    Random r = new Random();
                    int y1;
                    y1 = r.Next(-200, 000);
                    wall3 = new TheWall(500, y1, true);
                    wall4 = new TheWall(500, y1 + 400);
                    this.Text = "Flappy Bird Score: " + ++bird.score;
                }
            }
            else
            {
                if (wall1.x < bird.x - 300)
                {
                    Random r = new Random();
                    int y1;
                    y1 = r.Next(-200, 000);
                    wall1 = new TheWall(500, y1, true);
                    wall2 = new TheWall(500, y1 + 400);
                    this.Text = "Flappy Bird Score: " + ++bird.score;
                }

                if (wall3.x < bird.x - 300)
                {
                    Random r = new Random();
                    int y1;
                    y1 = r.Next(-200, 000);
                    wall3 = new TheWall(500, y1, true);
                    wall4 = new TheWall(500, y1 + 400);
                    this.Text = "Flappy Bird Score: " + ++bird.score;
                }
            }
            }

            private void MoveWalls()
            {

                if (bird.score < 5)
                {
                    wall1.x -= 2;
                    wall2.x -= 2;
                    wall3.x -= 2;
                    wall4.x -= 2;
                }
                else
                {
                    wall1.x -= 21 / 10;
                    wall2.x -= 21 / 10;
                    wall3.x -= 21 / 10;
                    wall4.x -= 21 / 10;
                }
                CreateNewWall();
            }


        private void button1_Click(object sender, EventArgs e)
        {


            if (bird.isAlive)
            {
                gravity = 0;
                bird.gravityValue = -0.140f;
            }
        }
        private void OnPaint(object sender, PaintEventArgs e)
            {

                Graphics graphics = e.Graphics;

                graphics.DrawImage(bird.birdImg, bird.x, bird.y, bird.size, bird.size);


                graphics.DrawImage(wall1.wallImg, wall1.x, wall1.y, wall1.sizeX, wall1.sizeY);

                graphics.DrawImage(wall2.wallImg, wall2.x, wall2.y, wall2.sizeX, wall2.sizeY);


                graphics.DrawImage(wall3.wallImg, wall3.x, wall3.y, wall3.sizeX, wall3.sizeY);

                graphics.DrawImage(wall4.wallImg, wall4.x, wall4.y, wall4.sizeX, wall4.sizeY);
            }
    }
    
}