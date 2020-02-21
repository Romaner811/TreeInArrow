using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.IFace
{
    public interface IBoardFiller
    {
        IItem GetSuitableItem(IBoard board, IPos pos);
    }
}
