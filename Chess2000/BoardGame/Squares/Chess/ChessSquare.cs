using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Location;
using Chess2000.BoardGame.Location.Chess;
using Chess2000.BoardGame.Movements.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules.Chess;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Squares.Chess
{
    public class ChessSquare : ISquare
    {
        private ISquareLocation _location { get; set; }
        
        public ChessSquare(ChessSquareLocation location)
        {
            _location = location;
        }

        public ISquareLocation GetLocation()
        {
            return _location;
        }
    }
}
