using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.Basic
{
    using IFace;

    public class BasicBoard : IBoard
    {
        private ISlot[,] slots;

        public BasicBoard(int width, int heigth, ISlotFactory factory)
        {
            this.Width = width;
            this.Heigth = heigth;

            this.slots = this.GenerateSlotArray(width, heigth, factory);
        }

        private ISlot[,] GenerateSlotArray(int width, int heigth, ISlotFactory factory)
        {
            ISlot[,] slots = new ISlot[width, heigth];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < heigth; y++)
                {
                    slots[x, y] = factory.Create(x, y);
                }
            }

            return slots;
        }

        public int Width { get; private set; }
        public int Heigth { get; private set; }

        public ISlot GetSlot(int x, int y)
        {
            return this.slots[x, y];
        }

        public ISlot GetSlot(IPos pos)
        {
            return this.GetSlot(pos.X, pos.Y);
        }
    }
}
