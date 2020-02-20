using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.Basic
{
    using IFace;

    class BasicSlot : ISlot
    {
        private IItem item = null;

        public BasicSlot(IItem item)
        {
            this.SetItem(item);
        }

        public BasicSlot() : this(null) { }

        public bool IsEmpty { get { return this.item is null; } }

        public void SetItem(IItem item)
        {
            this.item = item;
        }

        public IItem GetItem()
        {
            return this.item;
        }
    }
}
