using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity
{
    class Tank_Enemy: Tank
    {
        public Tank_Enemy(Point StartingPoint)
        {
            Rect = new Rectangle
            (
                StartingPoint.X * Config.TileSize + (Config.TileSize - this.Size) / 2,
                StartingPoint.Y * Config.TileSize + (Config.TileSize - this.Size) / 2,
                this.Size,
                this.Size
            );
        }
        public void Hit()
        {
            if (--this.healthpoints == 0) Game.Enemies.Remove(this);
        }

        public void Tick()
        {

        }
    }
}
