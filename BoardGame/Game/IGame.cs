using BoardGame.Location;
using BoardGame.Movements;
using BoardGame.Pieces;
using BoardGame.Rules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Game;

public interface IGame
{
    public ReadOnlyCollection<IPiece> GetAvailablePieces();
    public bool TryGetPiece(ISquareLocation location, out IPiece piece);
    public void ExecuteMove(IMovement move, IMovementsRules rules);
}
