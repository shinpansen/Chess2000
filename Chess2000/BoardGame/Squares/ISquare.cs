using Chess2000.BoardGame.Board;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Location;

namespace Chess2000.BoardGame.Squares
{
    public interface ISquare
    {
        public ISquareLocation GetLocation();
    }
}
