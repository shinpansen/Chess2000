using System;
using System.Collections.Generic;
using BoardGame.SquaresLocation.Chess;
using BoardGame.Movements;
using BoardGame.Pieces.Visitors;
using BoardGame.MovementsProviders;
using BoardGame.Squares;
using BoardGame.Squares.Chess;
using BoardGame.Board;
using BoardGame.Game;
using BoardGame.SquaresLocation;

namespace BoardGame.Pieces.Chess;

public abstract class ChessPiece : IPiece
{
    public ISquareLocation Location => GetSquare().GetLocation();
    public IMovement? LastMove { get; protected set; }
    protected ISquare Square;

    protected ChessPiece(ISquare square)
    {
        Square = square;
    }

    protected ChessPiece(ISquare square, IMovement? lastMove) : this(square)
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
    
    public IMovement? Visit(MovementPieceVisitor visitor)
    {
        return visitor.Visit(this);
    }

    public abstract List<IMovement> GetAvailableMoves(IGame game);
    public abstract List<IMovement> SimulateAvailableMoves(IGame game, IBoard board);
    public abstract IPiece Clone();
    public abstract IPiece Clone(ISquare newSquare);
    public abstract IPiece Clone(ISquare newSquare, IMovement? lastMove);
    public abstract bool Equals(IPiece? other);
}