using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Rules;
using System.Collections.Generic;

namespace Chess2000.BoardGame.Movement;

public interface IMovement
{
    public void ExecuteMove(List<IPiece> availablePieces, IMovementsRules rules);
}