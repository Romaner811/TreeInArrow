using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.Basic
{
    using IFace;

    public class BasicItemFactory : IItemFactory
    {
        public IItem Create(int typeID)
        {
            return new BasicItem(typeID);
        }
    }
}
