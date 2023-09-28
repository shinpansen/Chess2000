using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Location;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Movements;

public abstract class Movement : IMovement
{
    public List<IPiece> CloneAvailablePieces(IGame game)
    {
        var piecesClone = new List<IPiece>();
        game.GetAvailablePieces().ToList().ForEach(p => piecesClone.Add(p.Clone()));
        return piecesClone;
    }

    public bool TryGetPiece(List<IPiece> availablePieces, ISquareLocation location, out IPiece piece)
    {
        piece = default;
        piece = availablePieces.FirstOrDefault(p => p.GetSquare().GetLocation().Equals(location));
        return piece is not null;
    }

    public abstract List<IPiece> ExecuteMove(IGame game, IMovementsRules rules);
}
