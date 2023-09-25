using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess2000.BoardGame.Movement;

namespace Chess2000.BoardGame.Board
{
    public interface IBoard<TS>
        where TS : ISquare
    {
        public void ApplySquareMovement(IMovement<> board);
    }
}
