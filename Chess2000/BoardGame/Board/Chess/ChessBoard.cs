using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Squares.Chess;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Location;
using Chess2000.BoardGame.Location.Chess;

namespace Chess2000.BoardGame.Board.Chess
{
    public class ChessBoard : IBoard
    {
        private List<ISquare> _squares { get; set; }

        public ChessBoard()
        {
            _squares = new List<ISquare>();
            foreach (var col in ChessSquareLocation.AvailableColumns)
            {
                for (ushort r = 1; r < 8; r++)
                {
                    var location = new ChessSquareLocation(col, r);
                    _squares.Add(ChessSquareLocation.FirstRows.Contains(r) ? 
                        new ChessSquareFirstRow(location) : 
                        new ChessSquareBase(location));
                }
            }
        }

        public ISquare GetSquare(ISquareLocation squareLocation)
        {
            return _squares.First(s => s.GetLocation().Equals(squareLocation));
        }
    }
}
