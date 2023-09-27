using Chess2000.BoardGame.Pieces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Game
{
    public interface IGame
    {
        public ReadOnlyCollection<IPiece> GetAvailablePieces();
    }
}
