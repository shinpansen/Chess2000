using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Pieces
{
    public interface IPiece
    {
        public List<IMovement> GetAvailableMoves(IMovementsRules rules);
        public ISquare GetSquare();
        public IPiece Clone();
        public IPiece Clone(ISquare newSquare);
        public bool Visit(PiecesVisitor visitor);
    }
}
