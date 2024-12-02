using System.Drawing;

namespace Snake1125.Game.Objects
{
    internal class GameField : GameObject
    {
        Random random = new Random();
        public List<GameObject> objects { get; set; } = new();
        public List<GameObject> walls { get; set; } = new();
        public GameField()
        {
            AddObject(new Apple(random.Next(1, 29) * 10, random.Next(1, 29) * 10));
            AddObject(new Trap(random.Next(1, 29) * 10, random.Next(1, 29) * 10));

            walls.Add(new Wall (0,0));
        }

        void AddObject(GameObject gameObject)
        {
            objects.Add(gameObject);
        }

        internal void CheckIntersect(Snake snake, SnakeGame game)
        {
            var intersect = objects.FirstOrDefault(s => s.X == snake.X && s.Y == snake.Y);
            if (intersect != null)
            {
                if (intersect is ISnakeIntersect sIntersect)
                    sIntersect.Execute(snake, game);
                intersect.X = random.Next(1, 10) * 10;
                intersect.Y = random.Next(1, 10) * 10;
            }
        }
    }
}