using BoardGame.SquaresLocation;
using BoardGame.Movements;
using BoardGame.Pieces;
using BoardGame.Pieces.Chess;
using BoardGame.MovementsRules;
using BoardGame.MovementsRules.Chess;
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

    public virtual void ExecuteMove(IPiece piece, IMovement move, IMovementsRules rules)
    {
        var moves = rules.GetAvailableMoves(piece);
        if (!moves.Any(m => m.Equals(move)))
            throw new ArgumentException("Unauthorized move.");

        AvailablePieces = move.SimulateMove(this);
    }
}
