using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.Basic
{
    using IFace;

    // Redesign Rules System.
    class GravityRule : IRule
    {
        public IReadOnlyList<IMatchGroup> FindMatches(IBoard board, int x, int y)
        {
            List<IMatchGroup> matches = new List<IMatchGroup>(1);

            if (y > 0)
            {
                ISlot slotBelow = board.GetSlot(x, y - 1);
                if (slotBelow.IsEmpty)
                {
                    matches.Add(new MatchGroup(
                        this,
                        new List<IPos>(1)
                        {
                            new Pos(x, y)
                        }
                    ));
                }
            }

            return matches;
        }

        public void Apply(IBoard board, IMatchGroup group)
        {
            throw new NotImplementedException();
        }
    }
}
