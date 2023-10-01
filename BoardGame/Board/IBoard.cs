using BoardGame.Pieces;
using BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGame.Movements;
using BoardGame.SquaresLocation;

namespace BoardGame.Board;

public interface IBoard
{
    public ISquare GetSquare(ISquareLocation squareLocation);
}
