using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.IFace
{
    public interface IPos
    {
        int X { get; }
        int Y { get; }

        IPos StepInDirection(Direction dir);
    }
}
