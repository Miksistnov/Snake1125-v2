using System.Drawing;
using Snake1125.Game.Drawing.DrawObjects;
using Snake1125.Game.Objects;

namespace Snake1125.Game.Drawing
{
    internal class DrawSystem
    {
        Graphics graphics;
        Dictionary<Type, IDraw> draws = new();
        public DrawSystem()
        {
            this.graphics = Graphics.FromHwnd(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);

            RegistrationDraw(typeof(GameField), new GameFieldDraw());
            RegistrationDraw(typeof(Snake), new SnakeDraw());
            RegistrationDraw(typeof(Apple), new AppleDraw());
            RegistrationDraw(typeof(Trap), new TrapDraw());
            RegistrationDraw(typeof(Wall), new WallDraw());
            RegistrationDraw(typeof(Score), new ScoreDraw());
        }

        void RegistrationDraw(Type type, IDraw draw)
        {
            draws.Add(type, draw);
        }

        public void Draw(GameObject gameObject)
        {
            var type = gameObject.GetType();
            draws[type].Draw(gameObject, graphics);
        }

    }
}