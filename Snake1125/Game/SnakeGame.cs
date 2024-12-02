using Snake1125.Game.Drawing;
using Snake1125.Game.Drawing.DrawObjects;
using Snake1125.Game.Objects;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Sources;
using static System.Formats.Asn1.AsnWriter;

namespace Snake1125
{
    internal class SnakeGame
    {
        Random random = new Random();
        DrawSystem draw;
        GameField field;
        Control control;
        Snake snake;
        Score score;
        bool stop = false;

        public bool pause
        {
            get; set;  
        }

        public bool SnakeIsAlive { get => !stop && snake.IsAlive; }

        public SnakeGame()
        {


            draw = new DrawSystem();
            control = new Control();
            score = new Score(350, 10);
        }

        void CreateSnake()
        {
            snake = new Snake(50, 50);
            snake.OnIncrease += Snake_OnIncrease;
        }

        private void Snake_OnIncrease(object? sender, EventArgs e)
        {
            pointp(100);
        }

        internal void SendNewSnakeDirection(Direction direction)
        {

            if (snake.cells.Count > 1)
            {
                {
                    if (direction == Direction.up)
                    {
                        if (snake.Direction == Direction.down)
                            Stop();
                    }
                    if (direction == Direction.down)
                    {
                        if (snake.Direction == Direction.up)
                            Stop();
                    }
                    if (direction == Direction.left)
                    {
                        if (snake.Direction == Direction.right)
                            Stop();
                    }
                    if (direction == Direction.right)
                    {
                        if (snake.Direction == Direction.left)
                            Stop();
                    }
                }
            }
            snake.Direction = direction;

        }
       
        internal void Start()
        {
            stop = false;
            CreateSnake();
            field = new GameField();
            RunGame();
        }
        public void RunGame()
        {
            int speed = 210;
            int c = 0;
            control.Run(this);
            
            draw.Draw(field);
            foreach (var obj in field.walls)
                draw.Draw(obj);
            while (SnakeIsAlive)
            {
                if (pause == false)
                {
                     snake.Move();
                }
               
                field.CheckIntersect(snake, this);
                draw.Draw(snake);
                foreach (var obj in field.objects)
                    draw.Draw(obj);
                draw.Draw(score);
                // pp(score, graphics);
                Thread.Sleep(speed);

                if (snake.cells.Count > c && speed > 10)
                {
                    c = snake.cells.Count;
                    speed -= 10;
                    Thread.Sleep(speed);
                }

                //Thread.Sleep(200) это пауза для текущего потока в 200 миллисекуд. Код перестает выполняться и ждет указанное время. 1сек = 1000мс
                // чем меньше пауза, тем быстрее будет двигаться змейка
              
                if (snake.cells[0].X == 0 || snake.cells[0].X == 300 || snake.cells[0].Y == 0 || snake.cells[0].Y == 300)
                    Stop();
                if (snake.cells.Count > 4)
                {
                    for (int i = 1; i < snake.cells.Count; i++)
                    {
                        if (snake.cells[0].X == snake.cells[i].X && snake.cells[0].Y == snake.cells[i].Y)
                            Stop();

                    }
                }

            }
            Console.Beep();
            Console.WriteLine("Конец игры");
        }

        internal void Stop()
        {
            stop = true;
            Console.WriteLine("Игра прервана");
        }


        public void pointp(int point)
        {
            score.Increase( point);
        }

        public void pointm(int point)
        {
            score.Increase(-point);
        }
    } 
} 
