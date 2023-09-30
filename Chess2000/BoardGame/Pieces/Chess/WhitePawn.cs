using Chess2000.BoardGame.Data;
using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares;
using System;
using System.Collections.Generic;

namespace Chess2000.BoardGame.Pieces.Chess;

public sealed class WhitePawn : WhitePiece
{
    private WhitePawn(ISquare square) : base(square)
    {
    }

    private WhitePawn(ISquare square, IData data) : base(square, data)
    {
    }

    public WhitePawn(string location) : base(location)
    {
    }

    public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
    {
        if(rules is ChessMovementsRules chessMovementsRules)
            return chessMovementsRules.GetAvailableMoves(this);
        throw new ArgumentException("The piece can't follow this rules");
    }

    public override IData GetData()
    {
        return this.Data;
    }

    public override IPiece Clone()
    {
        return new WhitePawn(Square);
    }

    public override IPiece Clone(ISquare newSquare)
    {
        return new WhitePawn(newSquare);
    }

    public override IPiece Clone(ISquare newSquare, IData data)
    {
        return new WhitePawn(newSquare, data);
    }
}