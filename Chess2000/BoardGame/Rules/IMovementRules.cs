using System.Collections.Generic;
using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Movement;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Squares;

namespace Chess2000.BoardGame.Rules;

public interface IMovementRules<TM, in TP, in TB, TS, TSl>
    where TM : IMovement<TB, TS, TP, TSl>
    where TB : IBoard<TS, TP, TSl> 
    where TS : ISquare<TP, TSl> 
    where TP : IPiece 
    where TSl : ISquareLocation
{
    public List<TM> GetAvailableMoves(TP piece, TB board);
}