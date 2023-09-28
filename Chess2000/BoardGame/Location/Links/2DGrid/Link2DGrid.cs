using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Location.Links._2DGrid
{
    public class Link2DGrid : ISquareLink
    {
        public bool Equals(ISquareLink other)
        {
            return other.ToString().Equals(this.ToString());
        }
    }
}
