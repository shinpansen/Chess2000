using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Squares;

namespace Chess2000.BoardGame.Movement;

public interface IMovement<in TB, TS, TSl>
    where TB : IBoard<TS, TSl> 
    where TS : ISquare<TSl>
    where TSl : ISquareLocation<TSl>
{
    public void ApplyMovement(TB board);
}