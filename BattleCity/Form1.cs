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
        internal static bool isWDown = false, isADown = false, isSDown = false, isDDown = false;
        Tank_Player Tank_Player;
        Brush ShellBrush;
        TextureBrush RoadTexture, WallTexture;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(Config.MapSize * Config.TileSize, Config.MapSize * Config.TileSize);
            // 1 for wall, 0 for road
            // !!! i - Y, j - X
            Game.Map = new Map(new int[Config.MapSize, Config.MapSize]
            { 
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                { 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0},
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                { 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0},
                { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0},
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                { 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0},
                { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0}
            });

            Tank_Player = new Tank_Player(new Point(7, 12));
            //Tank_Enemy = new Tank[];
            Game.Enemies.Add(new Tank_Enemy(new Point(7, 0)));
            RoadTexture = new TextureBrush(BattleCity.Properties.Resources.road);
            WallTexture = new TextureBrush(BattleCity.Properties.Resources.wall);
            ShellBrush = new SolidBrush(Color.Silver);
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Game.Tick();
            Tank_Player.Move();
            picBox.Invalidate();
        }

        private void picBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            // Draw the map
            foreach (Tile tile in Game.Map.Tiles)
            if (tile.isWall)
            {
                g.FillRectangle(WallTexture, tile.Rect);
            }
            else
            {
                g.FillRectangle(RoadTexture, tile.Rect);
            }

            // Draw the objects
            Tank_Player.DrawTank(g);
            foreach (Tank_Enemy tank in Game.Enemies)
            {
                tank.DrawTank(g);
            }
            foreach (Shell shell in Game.Shells)
            {
                g.FillRectangle(ShellBrush, shell.Rect);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                isWDown = true;
            if (e.KeyCode == Keys.S)
                isSDown = true;
            if (e.KeyCode == Keys.A)
                isADown = true;
            if (e.KeyCode == Keys.D)
                isDDown = true;
            if (e.KeyCode == Keys.Space)
                Tank_Player.Shoot();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                isWDown = false;
            if (e.KeyCode == Keys.A)
                isADown = false;
            if (e.KeyCode == Keys.S)
                isSDown = false;
            if (e.KeyCode == Keys.D)
                isDDown = false;
        }

    }
}
