using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleCity
{
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

        public void Move()
        {
            Rectangle temp = this.Rect;
            if (Form1.isWDown)
            {
                this.Direction = (int)Directions.North;
                temp.Y -= velocity;
                if (!Collision.CollidesWith(temp))
                    this.Rect = temp;
            }
            if (Form1.isSDown)
            {
                this.Direction = (int)Directions.South;
                temp.Y += velocity;
                if (!Collision.CollidesWith(temp))
                    this.Rect = temp;
            }

            if (Form1.isADown)
            {
                this.Direction = (int)Directions.West;
                temp.X -= velocity;
                if (!Collision.CollidesWith(temp))
                    this.Rect = temp;
            }
            if (Form1.isDDown)
            {
                this.Direction = (int)Directions.East;
                temp.X += velocity;
                if (!Collision.CollidesWith(temp))
                    this.Rect = temp;
            }
        }

        public void Shoot()
        {
            if (this.LastAttack < Game.T - 60 / 10)
            {
                this.LastAttack = Game.T;
                Game.Shells.Add(new Shell(this));
            }
            
        }
    }
}
