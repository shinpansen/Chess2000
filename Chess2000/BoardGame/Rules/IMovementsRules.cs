using System.Collections.Generic;
using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Movement;
using Chess2000.BoardGame.Pieces;

namespace Chess2000.BoardGame.Rules;

public interface IMovementsRules
{
    public List<IMovement> GetAvailableMoves();
}