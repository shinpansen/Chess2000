using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Data;
using Chess2000.BoardGame.Location.Chess;
using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Pieces.Visitors;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class ChessPiece : IPiece
{
    public IMovement LastMove { get; protected set; }
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
    public abstract bool Visit(BooleanPieceVisitor visitor);

    public IMovement Visit(MovementPieceVisitor visitor)
    {
        return visitor.Visit(this);
    }
}