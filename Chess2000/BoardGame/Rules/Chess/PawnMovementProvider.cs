using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Rules.Chess;

public class PawnMovementProvider : ChessMovementProvider
{
    public PawnMovementProvider(ChessPiece piece, ChessPiecesController piecesController, ChessBoard board) : base(piece, piecesController, board)
    {
    }

    public Dictionary<string, ChessMovement> GetAvailableMoves(BlackPawn pawn)
    {
        return GetAvailableMoves(-1);
    }

    public Dictionary<string, ChessMovement> GetAvailableMoves(WhitePawn pawn)
    {
        return GetAvailableMoves(1);
    }

    private Dictionary<string, ChessMovement> GetAvailableMoves(int direction)
    {
        var movements = new Dictionary<string, ChessMovement>();

        //Basic forward move
        if(TryGetEmptySquare(Col, Row + direction, out var target))
            movements.Add(target._location.ToString(), new ChessMovementBase(Piece, target));
        
        //Eating opponent on the left
        if(TryGetSquareWithOpponent(Col-1, Row + direction, out var target2)) 
            movements.Add(target2._location.ToString(), new ChessMovementBase(Piece, target2));

        //Eating opponent on the right
        if (TryGetSquareWithOpponent(Col+1, Row + direction, out var target3))
            movements.Add(target3._location.ToString(), new ChessMovementBase(Piece, target3));

        return movements;
    }
}