using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.Basic
{
    using IFace;

    public class RandomItemBoardFiller : IBoardFiller
    {
        private int minID, maxID;
        private Random random;
        private IItemFactory itemFactory;

        public RandomItemBoardFiller(Random random, int minID, int maxID, IItemFactory itemFactory)
        {
            this.random = random;
            this.minID = minID;
            this.maxID = maxID;
            this.itemFactory = itemFactory;
        }

        protected int ChoseTypeID()
        {
            return this.random.Next(this.minID, this.maxID);
        }

        public IItem GetSuitableItem(IBoard board, IPos pos)
        {
            int typeID = this.ChoseTypeID();
            return this.itemFactory.Create(typeID);
        }
    }
}
