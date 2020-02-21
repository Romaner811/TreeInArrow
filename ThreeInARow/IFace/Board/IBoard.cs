using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.IFace
{
    public interface IBoard
    {
        int Width { get; }
        int Heigth { get; }
        ISlot GetSlot(int x, int y);
        ISlot GetSlot(IPos pos);
    }
}
