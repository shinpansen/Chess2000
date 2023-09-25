using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Movement.Chess;
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
    public abstract class ChessSquare : ISquare
    {
        public ChessSquareLocation Location { get; private set; }
        public ChessPiece Piece { get; private set; }
        
        protected ChessSquare(ChessSquareLocation location)
        {
            Location = location;
        }
        
        protected ChessSquare(ChessSquareLocation location, ChessPiece piece) : this(location)
        {
            Piece = piece;
        }

        public void MovePieceToNewSquare(ChessSquare newSquare, ChessMovement movement)
        {
            
            Piece.MoveToNewSquare(newSquare, movement);
            Piece = null;
        }
        
        private void DestroyPiece()
        {
            Piece?.Dispose();
            Piece = null;
        }
    }
}
