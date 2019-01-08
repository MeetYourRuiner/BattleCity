using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity
{
    public static class Config
    {
        public const int
            MapSize = 7,
            TileSize = 60,
            Tickrate = 1000 / 24;
    }

    class Game
    {
        public static Map Map { get; set; }
    }
}
