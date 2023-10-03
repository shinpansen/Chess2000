using BoardGame.Game;
using BoardGame.Pieces;
using BoardGame.Players;
using BoardGame.Squares;

namespace BoardGame.Movements.Chess;

public class ChessMovementSuper : IMovement
{
    private IPiece _pawn { get; set; }
    private ISquare _pawnTarget { get; set; }
    private IPiece _newPiece { get; set; }

    public ChessMovementSuper(IPiece pawn, ISquare pawnTarget, IPiece newPiece)
    {
        _pawn = pawn;
        _pawnTarget = pawnTarget;
        _newPiece = newPiece;
    }

    public List<IPiece> SimulateMove(IGame game, IPlayer player)
    {
        var piecesClone = new List<IPiece>(player.GetAvailablePieces());

        if (!player.TryGetPiece(_pawn.Location, out _)) return piecesClone;
        piecesClone.Remove(_pawn);
        piecesClone.Add(_newPiece.Clone(_pawnTarget, this));

        return piecesClone;
    }

    public bool Equals(IMovement? other)
    {
        if (other is not ChessMovementSuper otherMovement) return false;
        return otherMovement._pawn.Equals(this._pawn) &&
               otherMovement._pawnTarget.GetLocation().Equals(this._pawnTarget.GetLocation()) &&
               otherMovement._newPiece.Equals(this._newPiece);
    }
}