using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Movement.Chess;

public class ChessMovementRock : ChessMovement
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

    public override void ApplyMovement(ChessBoard board)
    {
        /*if (!IsSourceSquareValid(_kingSource) || !IsSourceSquareValid(_towerSource))
            throw new NullReferenceException("King or tower source square is empty");
        if (_kingTarget.Piece is not null || _towerTarget.Piece is not null)
            throw new ArgumentException("Some target squares aren't empty");

        board.ApplySquareMovement(_kingSource, _kingTarget);
        board.ApplySquareMovement(_towerSource, _towerTarget);*/
    }
}