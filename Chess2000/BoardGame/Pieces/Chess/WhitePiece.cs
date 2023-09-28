using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;
using Chess2000.BoardGame.Visitors;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class WhitePiece : ChessPiece
{
    protected WhitePiece(ISquare square) : base(square)
    {
    }
    
    public override bool Visit(PiecesVisitor visitor)
    {
        return visitor.Visit(this);
    }
}