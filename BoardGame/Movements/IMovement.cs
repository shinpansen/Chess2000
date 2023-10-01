using BoardGame.Board;
using BoardGame.Game;
using BoardGame.SquaresLocation;
using BoardGame.Pieces;
using BoardGame.MovementsRules;
using System;
using System.Collections.Generic;

namespace BoardGame.Movements;

public interface IMovement
{
    public List<IPiece> SimulateMove(IGame game);
}