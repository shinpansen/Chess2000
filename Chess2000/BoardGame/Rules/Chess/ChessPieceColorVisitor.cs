using Chess2000.BoardGame.Pieces.Chess;

namespace Chess2000.BoardGame.Rules.Chess;

public class ChessPieceColorVisitor
{
    private readonly ChessPiece _visitedPiece;
    
    public ChessPieceColorVisitor(ChessPiece visitedPiece)
    {
        _visitedPiece = visitedPiece;
    }

    public bool Visit(BlackPiece p1) => _visitedPiece is BlackPiece;

    public bool Visit(WhitePiece p1) => _visitedPiece is WhitePiece;
}