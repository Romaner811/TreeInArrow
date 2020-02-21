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

    public class UnityBoard: BasicBoard
    {
        private GameObject board;

        public UnityBoard(int width, int heigth, ISlotFactory slotFactory, GameObject board)
            : base(width, heigth, slotFactory)
        {
            this.board = board;
        }
    }
}
//>WIP
// TODO: + board slot filler
// TODO: we now should form the board...? or the board should form itself by us??? A: THEBOARD! it will receive us, and then be activated, so it can cahnge itself.
// or we transfer the monobehavior that will do the stuff?