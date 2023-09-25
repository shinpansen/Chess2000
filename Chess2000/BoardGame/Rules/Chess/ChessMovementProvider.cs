using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Squares.Chess;
using System.Linq;

namespace Chess2000.BoardGame.Rules.Chess;

public abstract class ChessMovementProvider
{
    protected ChessPiece Piece { get; private set; }
    protected ChessBoard Board { get; private set; }
    protected ChessPiecesController PiecesController { get; private set; }
    protected int Col => Piece.Square.Location.ToPoint().X;
    protected int Row => Piece.Square.Location.ToPoint().Y;

    protected ChessMovementProvider(ChessPiece piece, ChessPiecesController piecesController, ChessBoard board)
    {
        Piece = piece;
        PiecesController = piecesController;
        Board = board;
    }

    protected bool TryGetEmptySquare(int col, int row, out ChessSquare target)
    {
        target = default;
        if (!Board.TryGetSquareFromCoords(col, row, out var square)) return false;
        var piece = PiecesController.Pieces.FirstOrDefault(p => p.Square.Location.Equals(square.Location));
        return piece is null;
    }

    protected bool TryGetSquareWithOpponent(int col, int row, out ChessSquare target)
    {
        target = default;
        if (!Board.TryGetSquareFromCoords(col, row, out var square)) return false;
        var piece = PiecesController.Pieces.FirstOrDefault(p => p.Square.Location.Equals(square.Location));
        return piece is not null && !IsFriend(piece);
    }

    protected bool TryGetSquareEmptyOrWithOpponent(int col, int row, out ChessSquare target)
    {
        target = default;
        if (!Board.TryGetSquareFromCoords(col, row, out var square)) return false;
        var piece = PiecesController.Pieces.FirstOrDefault(p => p.Square.Location.Equals(square.Location));
        return piece is null || (piece is not null && !IsFriend(piece));
    }

    protected bool IsFriend(ChessPiece piece)
    {
        return Piece.IsFriend(new ChessPieceColorVisitor(piece));
    }
}