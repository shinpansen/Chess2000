using System;
using System.Collections.Generic;
using BoardGame.Game;
using BoardGame.Pieces;
using BoardGame.Players;
using BoardGame.Squares;

namespace BoardGame.Movements.Chess;

public class ChessMovementRock : IMovement
{
    private IPiece _king { get; set; }
    private ISquare _kingTarget { get; set; }
    private IPiece _tower { get; set; }
    private ISquare _towerTarget { get; set; }

    public ChessMovementRock(IPiece king, ISquare kingTarget, IPiece tower, ISquare towerTarget)
    {
        _king = king;
        _kingTarget = kingTarget;
        _tower = tower;
        _towerTarget = towerTarget;
    }

    public List<IPiece> SimulateMove(IGame game, IPlayer player)
    {
        var piecesClone = new List<IPiece>(player.GetAvailablePieces());

        if (player.TryGetPiece(_king.Location, out _))
        {
            piecesClone.Remove(_king);
            piecesClone.Add(_king.Clone(_kingTarget, this));
        }

        if (player.TryGetPiece(_tower.Location, out _))
        {
            piecesClone.Remove(_tower);
            piecesClone.Add(_tower.Clone(_towerTarget, this));
        }

        return piecesClone;
    }

    public bool Equals(IMovement? other)
    {
        if (other is not ChessMovementRock otherMovement) return false;
        return otherMovement._king.Equals(this._king) &&
            otherMovement._kingTarget.GetLocation().Equals(this._kingTarget.GetLocation()) &&
            otherMovement._tower.Equals(this._tower) &&
            otherMovement._towerTarget.GetLocation().Equals(this._towerTarget.GetLocation());
    }
}