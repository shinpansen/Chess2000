using System.Collections.Generic;
using System.Collections.ObjectModel;
using BoardGame.Board;
using BoardGame.Game;
using BoardGame.Movements;
using BoardGame.Pieces;

namespace BoardGame.MovementsRules;

public interface IMovementsRules
{
    public IGame GetGame();
    public IBoard GetBoard();
    public ReadOnlyCollection<IMovement> GetAvailableMoves(IPiece piece);
}