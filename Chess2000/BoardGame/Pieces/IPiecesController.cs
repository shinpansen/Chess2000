using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Movement;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Pieces
{
    public interface IPiecesController<TB, TP, TS, TSl, TM, in TMr, in TKey>
        where TB : IBoard<TS, TSl>
        where TP : IPiece<TS, TSl>
        where TS : ISquare<TSl>
        where TSl : ISquareLocation<TSl>
        where TM : IMovement<TB, TS, TSl>
        where TMr : IMovementRules<TB, TM, TS, TSl, TKey>
    {
        public List<TP> Pieces { get; }

        public void ApplyMove(TP piece, TKey moveKey);
    }
}
