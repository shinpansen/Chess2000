using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules.Chess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Game
{
    public abstract class Game : IGame
    {
        protected List<IPiece> AvailablePieces { get; set; }

        public Game()
        {
            AvailablePieces = new List<IPiece>();
        }

        public ReadOnlyCollection<IPiece> GetAvailablePieces()
        {
            return AvailablePieces.AsReadOnly();
        }

        public virtual void ExecuteMove(IMovement move)
        {
            AvailablePieces = move.ExecuteMove(this, null);
        }
    }
}
