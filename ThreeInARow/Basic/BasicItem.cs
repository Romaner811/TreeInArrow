﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.Basic
{
    using IFace;

    public class BasicItem : IItem
    {
        public BasicItem(int typeID)
        {
            this.TypeID = typeID;
        }

        public int TypeID { get; private set; }
    }
}
