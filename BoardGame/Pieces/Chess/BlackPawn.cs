using BoardGame.Data;
using BoardGame.Movements;
using BoardGame.MovementsRules;
using BoardGame.MovementsRules.Chess;
using BoardGame.Squares;
using System;
using System.Collections.Generic;

namespace BoardGame.Pieces.Chess;

public sealed class BlackPawn : BlackPiece
{
    private BlackPawn(ISquare square) : base(square)
    {
    }

    private BlackPawn(ISquare square, IMovement lastMove) : base(square, lastMove)
    {
    }

    public BlackPawn(string location) : base(location)
    {
    }

    public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
    {
        if (rules is ChessMovementsRules chessMovementsRules)
            return chessMovementsRules.GetAvailableMoves(this);
        throw new ArgumentException(nameof(BlackPawn) + " can't follow those rules");
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
}