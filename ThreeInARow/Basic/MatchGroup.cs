using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.Basic
{
    using IFace;

    struct MatchGroup : IMatchGroup
    {
        public MatchGroup(IRule rule, IReadOnlyList<IPos> slotPositions)
        {
            this.Rule = rule;
            this.SlotPositions = slotPositions;
        }

        public IRule Rule { get; private set; }
        public IReadOnlyList<IPos> SlotPositions { get; private set; }
    }
}
