using BoardGame.Data;
using BoardGame.Movements;
using BoardGame.MovementsRules;
using BoardGame.MovementsRules.Chess;
using BoardGame.Squares;
using BoardGame.SquaresLocation.Links._2DGrid;
using System;
using System.Collections.Generic;

namespace BoardGame.Pieces.Chess;

public sealed class WhitePawn : WhitePiece
{
    public WhitePawn(ISquare square) : base(square)
    {
    }

    public WhitePawn(ISquare square, IMovement lastMove) : base(square, lastMove)
    {
    }

    public WhitePawn(string location) : base(location)
    {
    }

    public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
    {
        var provider = new PawnMovementsProvider(rules, this);
        return provider.GetAvailableMoves(new Top());
    }

    public override IPiece Clone()
    {
        return new WhitePawn(Square);
    }

    public override IPiece Clone(ISquare newSquare)
    {
        return new WhitePawn(newSquare);
    }

    public override IPiece Clone(ISquare newSquare, IMovement lastMove)
    {
        return new WhitePawn(newSquare, lastMove);
    }

    public override bool Equals(IPiece? other)
    {
        if (other is not WhitePawn otherPiece) return false;
        return otherPiece.GetSquare().GetLocation().Equals(Square.GetLocation());
    }
}