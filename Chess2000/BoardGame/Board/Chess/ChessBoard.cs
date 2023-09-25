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
    public class ChessBoard : IBoard<ChessSquare, ChessMovement>
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

        public ChessSquare GetSquare(string location)
        {
            return Squares.First(s => s.Location.ToString().Equals(location));
        }

        public ChessSquare GetSquare(Point location)
        {
            return Squares.First(s => s.Location.ToPoint().Equals(location));
        }

        public ChessSquare GetSquare(int row, int column)
        {
            var location = new Point(column, row);
            return Squares.First(s => s.Location.ToPoint().Equals(location));
        }

        public bool TryGetSquare(string location, out ChessSquare square)
        {
            square = default;
            try
            {
                square = GetSquare(location);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TryGetSquare(Point location, out ChessSquare square)
        {
            square = default;
            try
            {
                square = GetSquare(location);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TryGetSquare(int column, int row, out ChessSquare square)
        {
            square = default;
            try
            {
                square = GetSquare(column, row);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ApplySquareMovement(ChessMovement movement)
        {
            movement.ApplyMovement(this);
        }
    }
}
