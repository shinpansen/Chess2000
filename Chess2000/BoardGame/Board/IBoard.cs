using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Board
{
    public interface IBoard<TS> where TS : ISquare
    {
        public void MovePiece(TS source, TS target);
        public bool IsSquareValid(TS square);
        public bool AreSquaresValid(List<TS> squares);
    }
}
