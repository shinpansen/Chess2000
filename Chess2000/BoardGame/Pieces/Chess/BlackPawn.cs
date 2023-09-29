using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares;
using System;
using System.Collections.Generic;

namespace Chess2000.BoardGame.Pieces.Chess;

public class BlackPawn : BlackPiece
{
    public BlackPawn(ISquare square) : base(square)
    {
    }

    public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
    {
        throw new NotImplementedException();
    }

    public override IPiece Clone()
    {
        return new BlackPawn(Square);
    }

    public override IPiece Clone(ISquare newSquare)
    {
        return new BlackPawn(newSquare);
    }
}