using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1125.Game.Objects
{
    internal class Score : GameObject
    {
        public int Value { get; set; }
        public Score(int x, int y)
        {
            X = x;
            Y = y;
        }

        internal void Increase(int point)
        {
           Value += point;
        }
    }
}

