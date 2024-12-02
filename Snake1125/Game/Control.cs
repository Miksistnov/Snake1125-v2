using Snake1125.Game.Objects;
using System.Diagnostics;

namespace Snake1125
{
    internal class Control
    {
        SnakeGame game;
        private int count { get; set; }
        internal void Run(SnakeGame game)
        {
            this.game = game;

            //Thread это класс для запуска метода в отдельном потоке. Отдельный поток нужен, чтобы метод мог выполняться обособленно
            //он не будет тормозить остальную часть программы
            Thread thread = new Thread(ListenKeyboard);
            thread.Start();
            
        }

        private void ListenKeyboard(object? obj)
        {
            int l = 0;
            while (game.SnakeIsAlive)
            {
                var key = Console.ReadKey();
                Console.SetCursorPosition(0, 0);
                Direction direction;
                switch (key.Key)
                {

                    case ConsoleKey.UpArrow:
                        direction = Direction.up;
                        break;
                    case ConsoleKey.DownArrow:
                        direction = Direction.down;
                        break;
                    case ConsoleKey.LeftArrow:
                        direction = Direction.left;
                        break;
                    case ConsoleKey.Spacebar:
                        count++;
                        direction = 0;
                        game.pause = true;
                        if (count % 2 == 0)   
                            game.pause = false;
                       break;
                    case ConsoleKey.R:
                        game.Stop();
                        SnakeGame gam = new SnakeGame();
                        gam.Start();
                        return;
                    case ConsoleKey.RightArrow:
                        direction = Direction.right;
                        break;
                    case ConsoleKey.Escape:
                        game.Stop();
                        return;

                    default:
                        continue;
                }
                game.SendNewSnakeDirection(direction);
            }
        }
    }
}