using BoardGame.Pieces.Chess;
using BoardGame.Squares.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGame.Movements.Chess;
using BoardGame.Squares;
using BoardGame.Location;
using BoardGame.Location.Chess;

namespace BoardGame.Board.Chess;

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
                var location = new ChessSquareLocation(col + r);
                /*_squares.Add(ChessSquareLocation.FirstRows.Contains(r) ? 
                    new ChessSquareFirstRow(location) : 
                    new ChessSquareBase(location));*/
                _squares.Add(new ChessSquare(location));
            }
        }
    }

    public ISquare GetSquare(ISquareLocation squareLocation)
    {
        return _squares.First(s => s.GetLocation().Equals(squareLocation));
    }
}
