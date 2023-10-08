using BoardGame.Pieces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGame.SquaresLocation;

namespace BoardGame.Players;

public abstract class Player : IPlayer
{
    public event EventHandler? BeforeTurnStarts;
    public event EventHandler? AfterTurnEnds;
    protected List<IPiece> AvailablePieces { get; set; }

    protected Player(List<IPiece> pieces)
    {
        AvailablePieces = pieces;
    }
    
    public ReadOnlyCollection<IPiece> GetAvailablePieces()
    {
        return AvailablePieces.AsReadOnly();
    }

    public bool TryGetPiece(ISquareLocation location, out IPiece piece)
    {
        piece = AvailablePieces.FirstOrDefault(p => p.Location.Equals(location));
        return piece is not null;
    }

    public virtual void OnBeforeTurnStarts(object sender, EventArgs e)
    {
        BeforeTurnStarts?.Invoke(this, e);
    }

    public virtual void OnAfterTurnEnds(object sender, EventArgs e)
    {
        AfterTurnEnds?.Invoke(this, e);
    }
}
