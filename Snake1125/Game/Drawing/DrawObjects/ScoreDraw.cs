using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake1125.Game.Objects;
using System.Drawing;

namespace Snake1125.Game.Drawing.DrawObjects
{
    internal class ScoreDraw : IDraw
    {
        public void Draw(GameObject gameObject, Graphics graphics)
        {
            var score = gameObject as Score;
            string sc = score.Value.ToString();
            Font font = new Font("Arial", 16);
            Brush brush = Brushes.White;
            Brush blackPen = Brushes.Black ;
            float x = 350;
            float y = 10;
            graphics.FillRectangle(blackPen, 350,10,1000,50);
            graphics.DrawString(sc, font, brush, x, y);
        }
    }

}
