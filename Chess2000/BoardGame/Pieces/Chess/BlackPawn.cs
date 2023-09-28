using System.Collections.Generic;
using System.Diagnostics;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public class BlackPawn : BlackPiece
{
    public BlackPawn(ISquare square) : base(square)
    {
    }
}