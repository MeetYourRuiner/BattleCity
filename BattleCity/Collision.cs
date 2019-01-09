using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity
{
    class Collision
    {
        public static bool CollidesWith(Rectangle rectangle, bool isTank = true)
        {
            var Walls = from t in Game.Map.Tiles.Cast<Tile>().ToArray()
                        where t.isWall == true
                        select t;

            foreach (var wall in Walls)
            {
                if (rectangle.IntersectsWith(wall.Rect))
                {
                    if (!isTank) wall.Wall_HP--;
                    return true;
                }
            }

            foreach (var tank in Game.Enemies)
            {
                if (rectangle.IntersectsWith(tank.Rect))
                {
                    tank.Hit();
                    return true;
                }
            }

            if (rectangle.X < 0 || rectangle.Y < 0 || rectangle.X > Config.MapSize * Config.TileSize - rectangle.Height || rectangle.Y > Config.MapSize * Config.TileSize - rectangle.Height)
                return true;

            return false;
        }
    }
}
