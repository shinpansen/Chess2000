using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Squares;

namespace Chess2000.BoardGame.Movement;

public interface IMovement<in TB, TS>
    where TB : IBoard<TS> 
    where TS : ISquare
{
    public void ApplyMovement(TB board);
}