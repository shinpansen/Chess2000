using BoardGame.Location;
using BoardGame.Movements;
using BoardGame.Pieces;
using BoardGame.Pieces.Chess;
using BoardGame.Rules;
using BoardGame.Rules.Chess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Game;

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
