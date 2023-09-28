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
    public abstract class Game<TPiece> : IGame<TPiece> where TPiece : IPiece
    {
        protected List<TPiece> AvailablePieces { get; set; }

        public Game()
        {
            AvailablePieces = new List<TPiece>();
        }

        public ReadOnlyCollection<TPiece> GetAvailablePieces()
        {
            return AvailablePieces.AsReadOnly();
        }
    }
}
