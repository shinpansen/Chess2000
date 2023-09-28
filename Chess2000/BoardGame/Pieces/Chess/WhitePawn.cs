using System.Collections.Generic;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public class WhitePawn : WhitePiece
{
    public WhitePawn(ISquare square) : base(square)
    {
    }
}