using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.Basic
{
    using IFace;

    class BasicSlotFactory : ISlotFactory
    {
        public ISlot Create()
        {
            return new BasicSlot();
        }
    }
}
