using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class ChessPiece : IPiece<ChessSquare, ChessSquareLocation>
{
    public ChessSquare Square { get; protected set; }
    public ChessMovement LastMove { get; protected set; }

    public ChessPiece(ChessSquare square)
    {
        Square = square;
    }
    
    public abstract bool IsFriend(ChessPieceColorVisitor piece);
    public abstract Dictionary<string, ChessMovement> GetAvailableMovements(ChessMovementRules rules);

    public void MoveToNewSquare(ChessSquare newSquare, ChessMovement movement)
    {
        Square = newSquare;
        LastMove = movement;
    }
}