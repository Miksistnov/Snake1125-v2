using Snake1125.Game.Objects;
using System.Drawing;

namespace Snake1125.Game.Drawing.DrawObjects
{
    internal interface IDraw
    {
        void Draw(GameObject gameObject, Graphics graphics);
    }
}