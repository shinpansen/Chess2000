using BoardGame.Pieces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGame.SquaresLocation;

namespace BoardGame.Players;

public interface IPlayer
{
    public ReadOnlyCollection<IPiece> GetAvailablePieces();
    public bool TryGetPiece(ISquareLocation location, out IPiece piece);
    public void OnBeforeTurnStarts(object sender, EventArgs e);
    public void OnAfterTurnEnds(object sender, EventArgs e);
}
