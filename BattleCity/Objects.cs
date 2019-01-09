using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity
{
    class Tank
    {
        protected int LastAttack = 0, velocity = 3, healthpoints = 1;
        public int Size = 30;
        public int Direction = (int)Directions.North;
        public Rectangle Rect { get; set; }

        public Tank()
        {
            Rect = new Rectangle(0, 0, Size, Size);
        }

        public void DrawTank(Graphics g)
        {
            var pic = BattleCity.Properties.Resources.tank;
            switch (Direction)
            {
                case (int)Directions.North:
                    break;
                case (int)Directions.East:
                    pic.RotateFlip(RotateFlipType.Rotate270FlipX);
                    break;
                case (int)Directions.South:
                    pic.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case (int)Directions.West:
                    pic.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }
            g.DrawImage(pic, this.Rect);
        }
    }

    class Shell
    {
        public Rectangle Rect { get; set; }
        private int width = 3, height = 7, direction, speed = 5;

        public Shell(Tank tank)
        {
            direction = tank.Direction;
            switch (direction)
            {
                case (int)Directions.North:
                    Rect = new Rectangle
                    (
                        tank.Rect.X + (tank.Size - this.width) / 2,
                        tank.Rect.Y - this.height,
                        width,
                        height
                    );
                    break;
                case (int)Directions.South:
                    Rect = new Rectangle
                    (
                        tank.Rect.X + (tank.Size - this.width) / 2,
                        tank.Rect.Y + tank.Size,
                        width,
                        height
                    );
                    break;
                case (int)Directions.West:
                    Rect = new Rectangle
                    (
                        tank.Rect.X - this.height,
                        tank.Rect.Y + (tank.Size - this.width) / 2,
                        height,
                        width
                        );
                    break;
                case (int)Directions.East:
                    Rect = new Rectangle
                    (
                        tank.Rect.X + tank.Size,
                        tank.Rect.Y + (tank.Size - this.width) / 2,
                        height,
                        width
                    );
                    break;
            }

        }

        public void Tick()
        {
            Rectangle temp = this.Rect;
            switch (direction)
            {
                case (int)Directions.North:
                    if (!Collision.CollidesWith(temp, false))
                        temp.Y -= speed;
                    else Game.Shells.Remove(this);
                    break;
                case (int)Directions.South:
                    if (!Collision.CollidesWith(temp, false))
                        temp.Y += speed;
                    else Game.Shells.Remove(this);
                    break;
                case (int)Directions.West:
                    if (!Collision.CollidesWith(temp, false))
                        temp.X -= speed;
                    else Game.Shells.Remove(this);
                    break;
                case (int)Directions.East:
                    if (!Collision.CollidesWith(temp, false))
                        temp.X += speed;
                    else Game.Shells.Remove(this);
                    break;
            }
            this.Rect = temp;
        }
    }
}
