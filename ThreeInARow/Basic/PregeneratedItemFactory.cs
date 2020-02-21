using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.Basic
{
    using IFace;

    public class PregeneratedItemFactory : IItemFactory
    {
        private int minID, maxID;
        private IItem[] items;

        public PregeneratedItemFactory(int minID, int maxID, IItemFactory factory)
        {
            this.minID = minID;
            this.maxID = maxID;
            this.items = this.GenerateItems(minID, maxID, factory);
        }

        private int CalcItemsCount(int minID, int maxID)
        {
            return maxID - minID;
        }

        private int CaleTypeIDIndex(int typeID)
        {
            return typeID - this.minID;
        }

        private IItem[] GenerateItems(int minID, int maxID, IItemFactory factory)
        {
            int arraySize = this.CalcItemsCount(minID, maxID);
            IItem[] result = new IItem[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                int typeID = minID + i;
                result[i] = factory.Create(typeID);
            }

            return result;
        }

        private IItem GetByTypeID(int typeID)
        {
            // TODO: error if typeID is out of range
            int idx = this.CaleTypeIDIndex(typeID);
            return this.items[idx];
        }

        public IItem Create(int typeID)
        {
            return this.GetByTypeID(typeID);
        }
    }
}
