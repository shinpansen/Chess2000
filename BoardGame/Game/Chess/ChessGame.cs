using BoardGame.Pieces.Chess;
using BoardGame.Squares.Chess;
using BoardGame.SquaresLocation.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Game.Chess;

public class ChessGame : Game
{
    public ChessGame()
    {
        AvailablePieces.Add(new WhiteBishop("C1"));
        AvailablePieces.Add(new BlackPawn("E3"));
        AvailablePieces.Add(new BlackPawn("G5"));
        //AvailablePieces.Add(new BlackPawn("B4"));
    }
}
