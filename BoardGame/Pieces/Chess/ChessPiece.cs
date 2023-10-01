using System;
using System.Collections.Generic;
using BoardGame.Data;
using BoardGame.SquaresLocation.Chess;
using BoardGame.Movements;
using BoardGame.Pieces.Visitors;
using BoardGame.MovementsRules;
using BoardGame.Squares;
using BoardGame.Squares.Chess;

namespace BoardGame.Pieces.Chess;

public abstract class ChessPiece : IPiece
{
    public IMovement? LastMove { get; protected set; }
    protected ISquare Square { get; set; }

    protected ChessPiece(ISquare square)
    {
        Square = square;
    }

    protected ChessPiece(ISquare square, IMovement lastMove) : this(square)
    {
        LastMove = lastMove;
    }

    protected ChessPiece(string location) : this(new ChessSquare(new ChessSquareLocation(location)))
    {
    }

    public ISquare GetSquare()
    {
        return Square;
    }

    public abstract List<IMovement> GetAvailableMoves(IMovementsRules rules);
    public abstract IPiece Clone();
    public abstract IPiece Clone(ISquare newSquare);
    public abstract IPiece Clone(ISquare newSquare, IMovement lastMove);
    public abstract bool Equals(IPiece? other);
    public abstract bool Visit(BooleanPieceVisitor visitor);

    public IMovement Visit(MovementPieceVisitor visitor)
    {
        return visitor.Visit(this);
    }
}