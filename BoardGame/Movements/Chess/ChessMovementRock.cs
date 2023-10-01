using System;
using System.Collections.Generic;
using BoardGame.Game;
using BoardGame.Pieces;
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

    public List<IPiece> SimulateMove(IGame game)
    {
        var piecesClone = new List<IPiece>(game.GetAvailablePieces());

        piecesClone.Remove(_king);
        piecesClone.Add(_king.Clone(_kingTarget, this));

        piecesClone.Remove(_tower);
        piecesClone.Add(_tower.Clone(_towerTarget, this));

        return piecesClone;
    }
}