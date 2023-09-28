using System.Collections.Generic;
using Chess2000.BoardGame.Location.Chess;
using Chess2000.BoardGame.Movements.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules.Chess;
using Microsoft.Xna.Framework;

namespace Chess2000.BoardGame.Squares.Chess;

public class ChessSquareBase : ChessSquare
{
    public ChessSquareBase(ChessSquareLocation location) : base(location)
    {
    }
}