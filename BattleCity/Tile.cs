using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity
{
    class Map
    {
        public Tile[,] Tiles;
        public Map(int[,] _map)
        {
            Tiles = new Tile[_map.GetLength(0), _map.GetLength(1)];
            for (int i = 0; i < _map.GetLength(0); i++)
                for (int j = 0; j < _map.GetLength(0); j++)
                    Tiles[i, j] = new Tile(_map[i,j], i, j);
        }
    }
    class Tile
    {
        public Rectangle Rect { get; set; }
        public bool isWall { get; set; }
        public int Wall_Durability { get; set; }

        public Tile(int _isWall, int i, int j)
        {
            isWall = (_isWall == 1);
            Rect = new Rectangle(Config.TileSize * j, Config.TileSize * i, Config.TileSize, Config.TileSize);
        }
    }
}
