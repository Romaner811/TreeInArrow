using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.Basic
{
    using IFace;

    public struct Pos : IPos
    {
        public Pos(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public IPos StepInDirection(Direction dir)
        {
            Pos nextPos = new Pos(this.X, this.Y);

            switch (dir)
            {
                case Direction.Up:
                    nextPos.Y++;
                    break;
                case Direction.Down:
                    nextPos.Y--;
                    break;
                case Direction.Rigth:
                    nextPos.X++;
                    break;
                case Direction.Left:
                    nextPos.X--;
                    break;
            }

            return nextPos;
        }
    }
}
