using BoardGame.Location.Links;
using BoardGame.Rules.Chess;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BoardGame.Location;

public interface ISquareLocation : IEquatable<ISquareLocation>
{
    public Dictionary<ISquareLink, ISquareLocation> GetNeighbors();
}