using Chess2000.BoardGame.Pieces.Chess;

namespace Chess2000.BoardGame.Rules.Chess;

public class ChessPieceVisitor : IPieceVisitor<bool, BlackPiece, WhitePiece>
{
    private readonly ChessPiece _pieceVisited;
    
    public ChessPieceVisitor(ChessPiece piece)
    {
        _pieceVisited = piece;
    }

    public bool Visit(BlackPiece p1) => _pieceVisited is BlackPiece;

    public bool Visit(WhitePiece p1) => _pieceVisited is WhitePiece;
}