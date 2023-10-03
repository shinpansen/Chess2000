using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using BoardGame.Game;
using BoardGame.Pieces;
using BoardGame.Pieces.Chess;
using BoardGame.Players;
using BoardGame.Squares;
using BoardGame.Squares.Chess;

namespace BoardGame.Movements.Chess;

public class ChessMovementEnPassant : IMovement
{
    private IPiece _pawn { get; set; }
    private ISquare _pawnTarget { get; set; }
    private IPiece _opponentPiece { get; set; }

    public ChessMovementEnPassant(IPiece pawn, ISquare pawnTarget, IPiece opponentPiece)
    {
        _pawn = pawn;
        _pawnTarget = pawnTarget;
        _opponentPiece = opponentPiece;
    }

    public List<IPiece> SimulateMove(IGame game, IPlayer player)
    {
        var piecesClone = new List<IPiece>(player.GetAvailablePieces());

        if (player.TryGetPiece(_pawn.Location, out _))
        {
            piecesClone.Remove(_pawn);
            piecesClone.Add(_pawn.Clone(_pawnTarget, this));
        }

        if (player.TryGetPiece(_opponentPiece.Location, out _))
            piecesClone.Remove(_opponentPiece);

        return piecesClone;
    }

    public bool Equals(IMovement? other)
    {
        if (other is not ChessMovementEnPassant otherMovement) return false;
        return otherMovement._pawn.Equals(this._pawn) &&
            otherMovement._pawnTarget.GetLocation().Equals(this._pawnTarget.GetLocation()) &&
            otherMovement._opponentPiece.Equals(this._opponentPiece);
    }
}