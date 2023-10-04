using BoardGame.Pieces.Chess;
using BoardGame.Squares.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGame.Movements.Chess;
using BoardGame.Squares;
using BoardGame.SquaresLocation;
using BoardGame.SquaresLocation.Chess;
using System.Collections.ObjectModel;

namespace BoardGame.Board.Chess;

public class ChessBoard : IBoard
{
    private List<ISquare> _availableSquares { get; set; }

    public ChessBoard()
    {
        _availableSquares = new List<ISquare>();
        foreach (var col in ChessSquareLocation.AvailableColumns)
        {
            for (ushort r = 1; r <= 8; r++)
            {
                var location = new ChessSquareLocation(col + r);
                _availableSquares.Add(new ChessSquare(location));
            }
        }
    }

    public ReadOnlyCollection<ISquare> GetAvailableSquares()
    {
        return _availableSquares.AsReadOnly();
    }

    public ISquare GetSquare(ISquareLocation squareLocation)
    {
        return _availableSquares.First(s => s.GetLocation().Equals(squareLocation));
    }
}
