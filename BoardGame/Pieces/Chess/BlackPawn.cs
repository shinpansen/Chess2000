using BoardGame.Board;
using BoardGame.Data;
using BoardGame.Game;
using BoardGame.Movements;
using BoardGame.MovementsProviders;
using BoardGame.MovementsProviders.Chess;
using BoardGame.Squares;
using BoardGame.SquaresLocation.Links._2DGrid;
using System;
using System.Collections.Generic;

namespace BoardGame.Pieces.Chess;

public sealed class BlackPawn : BlackPiece
{
    public BlackPawn(ISquare square) : base(square)
    {
    }

    public BlackPawn(ISquare square, IMovement lastMove) : base(square, lastMove)
    {
    }

    public BlackPawn(string location) : base(location)
    {
    }

    public override List<IMovement> GetAvailableMoves(IGame game, IBoard board)
    {
        var provider = new PawnMovementsProvider(game, board, this);
        return provider.GetAvailableMoves(new Bottom());
    }

    public override IPiece Clone()
    {
        return new BlackPawn(Square);
    }

    public override IPiece Clone(ISquare newSquare)
    {
        return new BlackPawn(newSquare);
    }

    public override IPiece Clone(ISquare newSquare, IMovement lastMove)
    {
        return new BlackPawn(newSquare, lastMove);
    }

    public override bool Equals(IPiece? other)
    {
        if (other is not BlackPawn otherPiece) return false;
        return otherPiece.GetSquare().GetLocation().Equals(Square.GetLocation());
    }
}