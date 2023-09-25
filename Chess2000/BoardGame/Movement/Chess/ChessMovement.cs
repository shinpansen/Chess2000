using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Movement.Chess;

public abstract class ChessMovement : 
    IMovement<ChessBoard, ChessPiece, ChessSquare, ChessSquareLocation, ChessMovement, ChessMovementRules, ChessPiecesController, string>
{
    public abstract void ApplyMove(ChessPiecesController controller);
}