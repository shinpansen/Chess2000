using BoardGame.Pieces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Players;

public interface IPlayer
{
    public ReadOnlyCollection<IPiece> GetAvailablePieces();
}
