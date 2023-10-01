using BoardGame.Data;
using BoardGame.Movements;
using BoardGame.MovementsRules;
using BoardGame.MovementsRules.Chess;
using BoardGame.Squares;
using System;
using System.Collections.Generic;

namespace BoardGame.Pieces.Chess;

public sealed class WhitePawn : WhitePiece
{
    private WhitePawn(ISquare square) : base(square)
    {
    }

    private WhitePawn(ISquare square, IMovement lastMove) : base(square, lastMove)
    {
    }

    public WhitePawn(string location) : base(location)
    {
    }

    public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
    {
        if(rules is ChessMovementsRules chessMovementsRules)
            return chessMovementsRules.GetAvailableMoves(this);
        throw new ArgumentException(nameof(WhitePawn) + " can't follow those rules");
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
}