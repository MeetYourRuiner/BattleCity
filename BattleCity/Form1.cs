using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleCity
{
    public partial class Form1 : Form
    {
        Tank_Player Tank_Player;
        Brush RoadBrush, WallBrush, PlayerBrush;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1 for wall, 0 for road
            // !!! i - Y, j - X
            Game.Map = new Map(new int[Config.MapSize, Config.MapSize]
            { 
                { 0, 0, 0, 0, 0, 0, 0},
                { 0, 1, 1, 1, 1, 1, 0},
                { 0, 0, 0, 0, 0, 0, 0},
                { 1, 0, 1, 0, 1, 0, 1},
                { 0, 0, 1, 0, 1, 0, 0},
                { 0, 1, 1, 0, 1, 1, 0},
                { 0, 0, 0, 0, 0, 0, 0}
            });

            Tank_Player = new Tank_Player(new Point(3, 6));
            RoadBrush = new SolidBrush(Color.Gray);
            PlayerBrush = new SolidBrush(Color.DarkGreen);
            WallBrush = new SolidBrush(Color.Black);
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            picBox.Invalidate();
        }

        private void picBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Draw the map
            foreach (Tile tile in Game.Map.Tiles)
            if (tile.isWall)
            {
                g.FillRectangle(WallBrush, tile.Rect);
            }
            else
            {
                g.FillRectangle(RoadBrush, tile.Rect);
            }
            // Draw the objects
            g.FillRectangle(PlayerBrush, Tank_Player.Rect);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.A:
                case Keys.S:
                case Keys.D:
                    Tank_Player.Move(e.KeyCode);
                    break;
                case Keys.Space:
                    break;
            }
        }      
    }
}
