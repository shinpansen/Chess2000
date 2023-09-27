using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Movement;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class ChessPiece : IPiece
{
    protected ISquare Square { get; set; }
    protected ChessMovement LastMove { get; set; }

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

    public void ExecuteAction(IMovement move)
    {
        throw new NotImplementedException();
    }

    public ISquare GetSquare()
    {
        return Square;
    }
}