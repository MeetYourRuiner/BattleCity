using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleCity
{
    class Tank
    {
        public int Size = 30;
        public Rectangle Rect { get; set; }

        public Tank()
        {
            Rect = new Rectangle(0, 0, Size, Size);
        }
    }

    class Tank_Player : Tank
    {
        public Tank_Player(Point StartingPoint)
        {
            Rect = new Rectangle
            (
                StartingPoint.X * Config.TileSize + (Config.TileSize - this.Size) / 2, 
                StartingPoint.Y * Config.TileSize + (Config.TileSize - this.Size) / 2, 
                this.Size, 
                this.Size
            );
        }

        public void Move(Keys key)
        {
            Rectangle temp;
            switch (key)
            {
                case Keys.W:
                    temp = this.Rect;
                    temp.Y--;
                    this.Rect = temp;
                    break;
                case Keys.A:
                    temp = this.Rect;
                    temp.X--;
                    this.Rect = temp;
                    break;
                case Keys.S:
                    temp = this.Rect;
                    temp.Y++;
                    this.Rect = temp;
                    break;
                case Keys.D:
                    temp = this.Rect;
                    temp.X++;
                    this.Rect = temp;
                    break;
            }
        }
    }
}
