using BoardGame.Pieces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Players;

public abstract class Player : IPlayer
{
    protected List<IPiece> AvailablePieces { get; set; }

    public Player(List<IPiece> pieces)
    {
        AvailablePieces = pieces;
    }

    public ReadOnlyCollection<IPiece> GetAvailablePieces()
    {
        return AvailablePieces.AsReadOnly();
    }
}
