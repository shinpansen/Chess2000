using System.Collections.Generic;
using System.Collections.ObjectModel;
using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Pieces;

namespace Chess2000.BoardGame.Rules;

public interface IMovementsRules
{
    public ReadOnlyCollection<IMovement> GetAvailableMoves();
}