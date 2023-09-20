using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Pieces.Chess;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Squares.Chess
{
    public abstract class ChessSquare : ISquare<ChessPiece, ChessSquareLocation>
    {
        private ChessSquareLocation _location { get; set; }
        private ChessPiece _piece { get; set; }
        
        protected ChessSquare(ChessSquareLocation location)
        {
            _location = location;
        }
        
        protected ChessSquare(ChessSquareLocation location, ChessPiece piece) : this(location)
        {
            _piece = piece;
        }

        public ChessSquareLocation GetLocation()
        {
            return _location;
        }

        public ChessPiece GetPiece()
        {
            return _piece;
        }
        
        public void SetPiece(ChessPiece piece)
        {
            _piece = piece;
        }
    }
}
