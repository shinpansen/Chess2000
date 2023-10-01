using Chess2000.BoardGame.Location.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Location;

public abstract class SquareLocation : ISquareLocation
{
    public virtual bool Equals(ISquareLocation? other) => (ToString() ?? string.Empty).Equals(other?.ToString());

    public abstract Dictionary<ISquareLink, ISquareLocation> GetNeighbors();
}
