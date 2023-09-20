using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Squares;

namespace Chess2000.BoardGame.Movement;

public interface IMovement<in TB, TS, TP, TSl> 
    where TB : IBoard<TS, TP, TSl> 
    where TS : ISquare<TP, TSl> 
    where TP : IPiece 
    where TSl : ISquareLocation
{
    public void ApplyMovement(TB board);
}