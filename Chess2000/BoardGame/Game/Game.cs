using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Game
{
    public abstract class Game : IGame
    {
        private List<IPiece> _availablePieces { get; set; }

        public Game(List<IPiece> pieces)
        {
            _availablePieces = pieces;
        }

        public ReadOnlyCollection<IPiece> GetAvailablePieces()
        {
            return _availablePieces.AsReadOnly();
        }
    }
}
