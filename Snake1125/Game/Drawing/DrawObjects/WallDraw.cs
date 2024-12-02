using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Snake1125.Game.Objects;
using static System.Net.Mime.MediaTypeNames;

namespace Snake1125.Game.Drawing.DrawObjects
{
    internal class WallDraw : IDraw
    {
 
        public WallDraw()
        {
            this.Size = new Size(40, 40);
            this.Paint = new PaintEventHandler(DrawWalls);
          
        }

  
        public Size Size { get; }
        public PaintEventHandler Paint { get; }
        public object DrawWalls { get; }

        public void Draw(GameObject gameObject, Graphics graphics)
        {

            Brush wallBrush = Brushes.Brown;

            graphics.FillRectangle(wallBrush, 0, 0, 2, 300);

            graphics.FillRectangle(wallBrush, 300, 0, 2, 300);
         
            graphics.FillRectangle(wallBrush, 0, 0, 300, 2);

            graphics.FillRectangle(wallBrush, 0, 300, 300, 2);
        }


    }

}
