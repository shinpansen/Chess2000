using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Rules.Chess;

public abstract class ChessMovementProvider
{
    protected ChessSquare Square { get; set; }
    protected ChessBoard Board { get; set; }
    protected int Col => Square.Location.ToPoint().X;
    protected int Row => Square.Location.ToPoint().Y;

    protected ChessMovementProvider(ChessSquare square, ChessBoard board)
    {
        Square = square;
        Board = board;
    }
    
    protected bool IsFriend(ChessSquare target)
    {
        return Square.Piece.IsFriend(new ChessPieceColorVisitor(target.Piece));
    }
}