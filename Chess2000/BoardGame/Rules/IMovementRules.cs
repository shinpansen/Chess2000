using System.Collections.Generic;
using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Movement;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Squares;

namespace Chess2000.BoardGame.Rules;

public interface IMovementRules<TM, in TS, in TB>
    where TM : IMovement<TB, TS>
    where TB : IBoard<TS> 
    where TS : ISquare
{
    public List<TM> GetAvailableMoves();
}