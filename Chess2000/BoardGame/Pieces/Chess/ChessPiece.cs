using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Data;
using Chess2000.BoardGame.Location.Chess;
using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class ChessPiece : IPiece
{
    protected ISquare Square { get; set; }
    protected IData Data { get; set; } = new Data.Data();

    protected ChessPiece(ISquare square)
    {
        Square = square;
    }

    protected ChessPiece(ISquare square, IData data) : this(square)
    {
        Data = data;
    }

    protected ChessPiece(string location) : this(new ChessSquare(new ChessSquareLocation(location)))
    {
    }

    public ISquare GetSquare()
    {
        return Square;
    }

    public abstract List<IMovement> GetAvailableMoves(IMovementsRules rules);
    public abstract IData GetData();
    public abstract IPiece Clone();
    public abstract IPiece Clone(ISquare newSquare);
    public abstract IPiece Clone(ISquare newSquare, IData data);
    public abstract IData Visit(PiecesVisitor visitor);
}