using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Movements.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;
using Chess2000.BoardGame.Visitors;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class ChessPiece : IPiece
{
    protected ISquare Square { get; set; }
    protected IMovement LastMove { get; set; }

    public ChessPiece(ISquare square)
    {
        Square = square;
    }

    public abstract bool Visit(PiecesVisitor visitor);

    public abstract List<IMovement> GetAvailableMoves(IMovementsRules rules);

    public ISquare GetSquare()
    {
        return Square;
    }

    public abstract IPiece Clone();
    public abstract IPiece Clone(ISquare newSquare);
}