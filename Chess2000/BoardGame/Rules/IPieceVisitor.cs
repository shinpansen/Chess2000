using Chess2000.BoardGame.Pieces;

namespace Chess2000.BoardGame.Rules;

public interface IPieceVisitor<in T1, in T2, out TResult> 
    where T1 : IPiece 
    where T2 : IPiece
{
    public TResult Visit(T1 p1);
    public TResult Visit(T2 p1);
}