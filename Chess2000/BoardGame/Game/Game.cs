using Chess2000.BoardGame.Location;
using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Rules.Chess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Game
{
    public abstract class Game : IGame
    {
        protected List<IPiece> AvailablePieces { get; set; } = new();

        public ReadOnlyCollection<IPiece> GetAvailablePieces()
        {
            return AvailablePieces.AsReadOnly();
        }

        public bool TryGetPiece(ISquareLocation location, out IPiece piece)
        {
            piece = AvailablePieces.FirstOrDefault(p => p.GetSquare().GetLocation().Equals(location));
            return piece is not null;
        }

        public virtual void ExecuteMove(IMovement move, IMovementsRules rules)
        {
            if (!rules.GetAvailableMoves().Contains(move))
                throw new ArgumentException(@"Unauthorized move. 
                    The instance of 'rules' should be the same you got the 'move' from");

            AvailablePieces = move.SimulateMove(this);
        }
    }
}
