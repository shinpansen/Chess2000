using BoardGame.Board;
using BoardGame.Game;
using BoardGame.Location;
using BoardGame.Pieces;
using BoardGame.Rules;
using System;
using System.Collections.Generic;

namespace BoardGame.Movements;

public interface IMovement
{
    public List<IPiece> SimulateMove(IGame game);
}