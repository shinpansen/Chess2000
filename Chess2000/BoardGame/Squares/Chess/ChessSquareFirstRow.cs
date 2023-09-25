using System.Collections.Generic;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules.Chess;
using Microsoft.Xna.Framework;

namespace Chess2000.BoardGame.Squares.Chess;

public class ChessSquareFirstRow : ChessSquare
{
    public ChessSquareFirstRow(ChessSquareLocation location) : base(location)
    {
    }

    public ChessSquareFirstRow(ChessSquareLocation location, ChessPiece piece) : base(location, piece)
    {
    }
}