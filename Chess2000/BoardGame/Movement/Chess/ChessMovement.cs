using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Movement.Chess;

public abstract class ChessMovement : IMovement<ChessBoard, ChessSquare, ChessSquareLocation>
{
    public abstract void ApplyMovement(ChessBoard board);
}