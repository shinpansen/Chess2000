using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Squares;

namespace Chess2000.BoardGame.Movements.Chess;

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
        piecesClone.Add(_king.Clone(_kingTarget, new Data.Data("LastMove", this)));

        piecesClone.Remove(_tower);
        piecesClone.Add(_tower.Clone(_towerTarget, new Data.Data("LastMove", this)));

        return piecesClone;
    }
}