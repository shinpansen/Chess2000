using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Location;

namespace Chess2000.BoardGame.Board;

public interface IBoard
{
    public ISquare GetSquare(ISquareLocation squareLocation);
}
