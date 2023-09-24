using System.Diagnostics;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public class BlackPawn : BlackPiece
{
    public override bool CanRock() => false;
}