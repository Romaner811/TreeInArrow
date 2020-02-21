using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.IFace
{
    public interface IMove
    {
        IPos SlotPosition { get; }
        Direction SwapDirection { get; }
    }
}
