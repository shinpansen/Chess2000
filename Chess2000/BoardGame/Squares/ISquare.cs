using Chess2000.BoardGame.Board;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess2000.BoardGame.Pieces;

namespace Chess2000.BoardGame.Squares
{
    public interface ISquare<TP, out TSl> where TP : IPiece where TSl : ISquareLocation
    {
        public TSl GetLocation();
        public TP GetPiece();
        public void SetPiece(TP piece);
    }
}
