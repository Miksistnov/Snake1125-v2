using Snake1125.Game.Objects;
using System.Drawing;

namespace Snake1125.Game.Drawing.DrawObjects
{
    internal class GameFieldDraw : IDraw
    {
        public void Draw(GameObject gameObject, Graphics graphics)
        {

            graphics.Clear(Color.Black);
        }
    }
}