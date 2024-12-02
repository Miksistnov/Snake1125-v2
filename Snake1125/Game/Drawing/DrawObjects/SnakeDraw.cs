using Snake1125.Game.Objects;
using System.Drawing;

namespace Snake1125.Game.Drawing.DrawObjects
{
    internal class SnakeDraw : IDraw
    {
        public void Draw(GameObject gameObject, Graphics graphics)
        {
            Snake snake = (Snake)gameObject;
            var tale = snake.Tale;
            while (tale != null)
            {
                graphics.FillEllipse(Brushes.Black, tale.X, tale.Y, 10, 10);
                tale = snake.Tale;
            }
            graphics.FillEllipse(Brushes.Green, snake.X, snake.Y, 10, 10);
        }
    }
}