using System.Collections.Generic;
using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Movement;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Squares;

namespace Chess2000.BoardGame.Rules;

public interface IMovementRules<TB, TM, TS, TSl, TKey>
    where TB : IBoard<TS, TSl>
    where TM : IMovement<TB, TS, TSl>
    where TS : ISquare<TSl>
    where TSl : ISquareLocation<TSl>
{
    public Dictionary<TKey, TM> GetAvailableMoves();
}