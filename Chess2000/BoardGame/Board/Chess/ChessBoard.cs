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
    public class ChessBoard : IBoard<ChessSquare, ChessSquareLocation>
    {
        public List<ChessSquare> Squares { get; private set; }

        public ChessBoard()
        {
            Squares = new List<ChessSquare>();
            foreach (var col in ChessSquareLocation.AvailableColumns)
            {
                for (ushort r = 1; r < 8; r++)
                {
                    var location = new ChessSquareLocation(col, r);
                    Squares.Add(ChessSquareLocation.FirstRows.Contains(r) ? 
                        new ChessSquareFirstRow(location) : 
                        new ChessSquareBase(location));
                }
            }
        }

        public ChessSquare GetSquare(ChessSquareLocation squareLocation)
        {
            return Squares.First(s => s.Location.Equals(squareLocation));
        }

        public bool TryGetSquare(ChessSquareLocation squareLocation, out ChessSquare square)
        {
            square = default;
            try
            {
                square = GetSquare(squareLocation);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ChessSquare GetSquareFromCoords(int row, int column)
        {
            var location = new Point(column, row);
            return Squares.First(s => s.Location.ToPoint().Equals(location));
        }

        public bool TryGetSquareFromCoords(int column, int row, out ChessSquare square)
        {
            square = default;
            try
            {
                square = GetSquareFromCoords(column, row);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
