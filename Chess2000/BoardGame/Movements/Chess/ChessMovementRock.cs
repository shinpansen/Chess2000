using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Movements.Chess;

public class ChessMovementRock 
{
    private ChessSquare _kingSource { get; set; }
    private ChessSquare _kingTarget { get; set; }
    private ChessSquare _towerSource { get; set; }
    private ChessSquare _towerTarget { get; set; }

    public ChessMovementRock(ChessSquare kingSource, ChessSquare kingTarget, 
        ChessSquare towerSource, ChessSquare towerTarget)
    {
        _kingSource = kingSource;
        _kingTarget = kingTarget;
        _towerSource = towerSource;
        _towerTarget = towerTarget;
    }

    public void ExecuteMove()
    {
        throw new NotImplementedException();
    }
}