using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class ChessPiece : IPiece
{
    public ChessSquare Square { get; private set; }
    public ChessMovement LastMove { get; private set; }

    public ChessPiece(ChessSquare square)
    {
        Square = square;
    }
    
    public abstract bool IsFriend(ChessPieceColorVisitor piece);
    public abstract List<ChessMovement> GetAvailableMovements(ChessMovementRules rules);

    public void MoveToNewSquare(ChessSquare newSquare, ChessMovement movement)
    {
        Square = newSquare;
        LastMove = movement;
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}