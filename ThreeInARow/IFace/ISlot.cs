using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.IFace
{
    interface ISlot
    {
        void SetItem(IItem item);
        IItem GetItem();
        bool IsEmpty { get; }
    }
}
