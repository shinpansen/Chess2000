using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Squares.Chess;
using Chess2000.BoardGame.Location.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Game.Chess
{
    public class ChessGame : Game
    {
        public ChessGame() : base()
        {
            AvailablePieces.Add(new WhitePawn("B2"));
            //AvailablePieces.Add(new BlackPawn("B4"));
        }
    }
}
