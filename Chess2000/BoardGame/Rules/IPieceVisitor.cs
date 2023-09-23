using Chess2000.BoardGame.Pieces;

namespace Chess2000.BoardGame.Rules;

public interface IPieceVisitor<out TResult, in T1, in T2> 
    where T1 : IPiece 
    where T2 : IPiece
{
    public TResult Visit(T1 p1);
    public TResult Visit(T2 p1);
}