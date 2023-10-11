using BoardGame.Board;
using BoardGame.Game;
using BoardGame.SquaresLocation;
using BoardGame.Pieces;
using BoardGame.MovementsProviders;
using System;
using System.Collections.Generic;
using BoardGame.Players;

namespace BoardGame.Movements;

public interface IMovement : IEquatable<IMovement>
{
    public ISquareLocation? TargetLocation { get; }
    public List<IPiece> SimulateMove(IGame game, IPlayer player);
}