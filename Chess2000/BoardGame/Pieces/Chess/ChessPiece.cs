using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Movement;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class ChessPiece : IPiece
{
    protected ISquare Square { get; set; }
    protected IMovement LastMove { get; set; }

    public ChessPiece(ISquare square)
    {
        Square = square;
    }
    
    public abstract bool IsFriend(ChessPieceColorVisitor piece);

    public List<IMovement> GetAvailableMoves(IMovementsRules rules)
    {
        throw new NotImplementedException();
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