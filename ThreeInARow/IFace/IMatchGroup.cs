using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.IFace
{
    interface IMatchGroup
    {
        IRule Rule { get; }
        IReadOnlyList<IPos> SlotPositions { get; }
    }
}
