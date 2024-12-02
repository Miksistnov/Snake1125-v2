using Snake1125.Game.Objects;

namespace Snake1125
{
    internal class Apple : GameObject, ISnakeIntersect
    {
        public Apple(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Execute(Snake snake,SnakeGame game)
        {
            snake.Increase(game);
        }
    }
}