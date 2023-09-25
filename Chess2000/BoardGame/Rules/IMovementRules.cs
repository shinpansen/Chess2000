using System.Collections.Generic;
using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Movement;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Squares;

namespace Chess2000.BoardGame.Rules;

public interface IMovementRules<TB, TP, TS, TSl, TM, TMr, TC, TKey>
     where TB : IBoard<TS, TSl>
        where TP : IPiece<TS, TSl>
        where TS : ISquare<TSl>
        where TSl : ISquareLocation<TSl>
        where TM : IMovement<TB, TP, TS, TSl, TM, TMr, TC, TKey>
        where TMr : IMovementRules<TB, TP, TS, TSl, TM, TMr, TC, TKey>
        where TC : IPiecesController<TB, TP, TS, TSl, TM, TMr, TC, TKey>
{
    public Dictionary<TKey, TM> GetAvailableMoves();
}