using Chess2000.BoardGame.Location.Links;
using Chess2000.BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Rules
{
    public interface IMovementProvider
    {
        public bool TryGetSquare(Queue<ISquareLink> links, out ISquare square);
    }
}
