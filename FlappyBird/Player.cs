using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FlappyBird
{
    

    class Player
    {
        public float x;
        public float y;

        public int size;
        public int score;

        public float gravityValue;

        public Image birdImg;

        public bool isAlive;

        public Player(int x,int y)
        {
            birdImg = new Bitmap(@"D:\данияра папка\С#\semeчkи\3-sem\birdImg3.jpg");
            this.x = x;
            this.y = y;
            size = 40;
            gravityValue = 0.1f;
            isAlive = true;
            score = 0;
        }
    }
}
