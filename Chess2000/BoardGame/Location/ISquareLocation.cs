using Chess2000.BoardGame.Location.Links;
using Chess2000.BoardGame.Rules.Chess;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Chess2000.BoardGame.Location;

public interface ISquareLocation : IEquatable<SquareLocation>
{
    public Dictionary<ISquareLink, ISquareLocation> GetNeighbors();
}