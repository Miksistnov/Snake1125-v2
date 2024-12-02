using Snake1125.Game.Objects;

namespace Snake1125
{
    internal class Trap : GameObject, ISnakeIntersect
    {
        public Trap(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Execute(Snake snake, SnakeGame game)
        {
            snake.Decrease(game);
        }
    }
}