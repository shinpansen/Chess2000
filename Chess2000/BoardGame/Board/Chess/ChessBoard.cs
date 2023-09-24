using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Squares.Chess;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess2000.BoardGame.Movement.Chess;

namespace Chess2000.BoardGame.Board.Chess
{
    public class ChessBoard : IBoard<ChessSquare>
    {
        public List<ChessSquare> Squares { get; private set; }

        public ChessBoard()
        {
            Squares = new List<ChessSquare>();
            foreach (var col in ChessSquareLocation.AvailableColumns)
            {
                for (ushort r = 1; r < 8; r++)
                {
                    var location = new ChessSquareLocation(r, col);
                    Squares.Add(ChessSquareLocation.FirstRows.Contains(r) ? 
                        new ChessSquareFirstRow(location) : 
                        new ChessSquareBase(location));
                }
            }
        }

        public void MovePiece(ChessSquare source, ChessSquare target)
        {
            target.Piece = source.Piece;
            source.DestroyPiece();
        }

        public bool IsSquareValid(ChessSquare square)
        {
            return Squares.Contains(square);
        }

        public bool AreSquaresValid(List<ChessSquare> squares)
        {
            foreach (ChessSquare square in squares)
                if (!IsSquareValid(square))
                    return false;
            return true;
        }
        
        public void ApplyMovement(ChessMovementBase movement)
        {
            movement.ApplyMovement(this);
        }
        
        public void ApplyMovement(ChessMovementRock movement)
        {
            movement.ApplyMovement(this);
        }
    }
}
