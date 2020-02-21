using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace ThreeInARow.Unity
{
    using IFace;
    using Basic;

    public class UnityItem : BasicItem
    {
        private GameObject item;

        public UnityItem(int typeID, GameObject item)
            : base(typeID)
        {
            this.item = item;
        }
    }
}
//>WIP
