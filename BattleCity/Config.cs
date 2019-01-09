using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleCity
{
    public static class Config
    {
        public const int
            MapSize = 15,
            TileSize = 40,
            Tickrate = 1000 / 60;
    }

    class Game
    {
        public static int T = 0;
        public static Map Map { get; set; }
        public static List<Shell> Shells = new List<Shell>();
        public static List<Tank_Enemy> Enemies= new List<Tank_Enemy>();
        public static void Tick()
        {
            T++;
            for (int i = 0; i < Shells.Count; i++)
            {
                Shells[i].Tick();
            }
            foreach (Tank_Enemy tank in Enemies)
            {
                tank.Tick();
            }
            foreach (Tile tile in Map.Tiles)
            {
                tile.Tick();
            }
        }
    }
}
