using System.Collections.Generic;
using System.Diagnostics;
using Chess2000.BoardGame.Movements.Chess;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public class BlackPawn : BlackPiece
{
    public BlackPawn(ISquare square) : base(square)
    {
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