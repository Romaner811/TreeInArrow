using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.Basic
{
    using IFace;

    class RandomBaseItemFactory : IItemFactory
    {
        private int minID, maxID;
        private Random random;
        private IItem[] items;

        public RandomBaseItemFactory(Random random, int minID, int maxID)
        {
            this.random = random;

            this.items = this.GenerateItems(minID, maxID);
        }

        private IItem[] GenerateItems(int minID, int maxID)
        {
            int arraySize = maxID + minID + 1;
            IItem[] result = new IItem[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                int typeID = minID + i;
                result[i] = this.CreateFromTypeID(typeID);
            }

            return result;
        }

        protected IItem CreateFromTypeID(int typeID)
        {
            return new BasicItem(typeID);
        }

        protected int ChoseTypeID()
        {
            return this.random.Next(this.minID, this.maxID);
        }

        protected IItem GetByTypeID(int typeID)
        {
            int idx = this.minID + typeID;
            return this.items[idx];
        }

        public IItem Create()
        {
            int typeID = this.ChoseTypeID();
            return this.GetByTypeID(typeID);
        }
    }
}
