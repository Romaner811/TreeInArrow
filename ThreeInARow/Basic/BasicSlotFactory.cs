using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.Basic
{
    using IFace;

    public class BasicSlotFactory : ISlotFactory
    {
        public ISlot Create(int x, int y)
        {
            return new BasicSlot();
        }
    }
}
