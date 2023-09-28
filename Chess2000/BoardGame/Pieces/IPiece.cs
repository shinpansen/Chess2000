using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Movement;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares;
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
        public void ExecuteAction(IMovement move);
        public ISquare GetSquare();
    }
}
