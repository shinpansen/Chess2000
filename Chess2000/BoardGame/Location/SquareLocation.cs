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
        public virtual bool Equals(SquareLocation other)
        {
            var coordinates = ToCoordinates();
            var otherCoordinates = other.ToCoordinates();

            if(coordinates.Count != otherCoordinates.Count) return false;

            foreach(var c in coordinates)
                if (!otherCoordinates.TryGetValue(c.Key, out var val) || val != c.Value) 
                    return false;
            return true;
        }

        public abstract Dictionary<ISquareLink, ISquareLocation> GetNeighbors();

        protected abstract Dictionary<string, object> ToCoordinates();
    }
}
