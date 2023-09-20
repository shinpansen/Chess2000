using System.Collections.Generic;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Rules.Chess;

public class ChessMovementRules : IMovementRules<ChessMovement, ChessPiece, ChessBoard, ChessSquare, ChessSquareLocation>
{
    public List<ChessMovement> GetAvailableMoves(ChessPiece piece, ChessBoard board)
    {
        throw new System.NotImplementedException();
    }
} 