using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FlappyBird
{
    class TheWall
    {
        public int x;
        public int y;

        public int sizeX;
        public int sizeY;

        public Image wallImg;

        public TheWall(int x, int y,bool isRotatedImage=false)
        {
            wallImg = new Bitmap(@"D:\данияра папка\С#\semeчkи\3-sem\wallimg.jfif");
            this.x = x;
            this.y = y;
            sizeX = 50;
            sizeY = 250;
            if(isRotatedImage)
                wallImg.RotateFlip(RotateFlipType.Rotate180FlipX);
        }
    }
}
