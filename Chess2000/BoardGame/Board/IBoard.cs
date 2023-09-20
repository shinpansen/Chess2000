using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Board
{
    public interface IBoard<TSt, TP, TS> 
        where TSt : ISquare<TP, TS>
        where TP : IPiece 
        where TS : ISquareLocation
    {
        public void MovePiece(TSt source, TSt target);
        public bool IsSquareValid(TSt square);
        public bool AreSquaresValid(List<TSt> squares);
    }
}
