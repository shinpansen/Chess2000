using Chess2000.BoardGame.Location.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Location
{
    public abstract class SquareLocation : ISquareLocation
    {
        public virtual bool Equals(ISquareLocation other)
        {
            return this.ToString().Equals(other.ToString());
        }

        public abstract Dictionary<ISquareLink, ISquareLocation> GetNeighbors();
    }
}
