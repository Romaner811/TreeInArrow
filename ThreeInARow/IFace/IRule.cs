using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.IFace
{
    interface IRule
    {
        IReadOnlyList<IMatchGroup> FindMatches(IBoard board, int x, int y);
        void Apply(IBoard board, IMatchGroup group);
    }
}
