using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Visitors;
using System;
using System.Collections.Generic;

namespace Chess2000.BoardGame.Pieces.Chess;

public class WhitePawn : WhitePiece
{
    public WhitePawn(ISquare square) : base(square)
    {
    }

    public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
    {
        return rules.GetAvailableMoves(this);
    }

    public override IPiece Clone()
    {
        return new WhitePawn(Square);
    }

    public override IPiece Clone(ISquare newSquare)
    {
        return new WhitePawn(newSquare);
    }
}