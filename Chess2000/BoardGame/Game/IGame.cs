﻿using Chess2000.BoardGame.Location;
using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Rules;
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
        public bool TryGetPiece(ISquareLocation location, out IPiece piece);
        public void ExecuteMove(IMovement move, IMovementsRules rules);
    }
}
