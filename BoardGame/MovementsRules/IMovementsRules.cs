using System.Collections.Generic;
using System.Collections.ObjectModel;
using BoardGame.Board;
using BoardGame.Game;
using BoardGame.Movements;
using BoardGame.Pieces;

namespace BoardGame.MovementsRules;

public interface IMovementsRules
{
    public ReadOnlyCollection<IMovement> GetAvailableMoves();
}