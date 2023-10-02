using BoardGame.SquaresLocation.Links;
using BoardGame.MovementsProviders.Chess;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BoardGame.SquaresLocation;

public interface ISquareLocation : IEquatable<ISquareLocation>
{
    public Dictionary<ISquareLink, ISquareLocation> GetNeighbors();
}