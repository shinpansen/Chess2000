using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Movement.Chess;

public class ChessMovementBase : ChessMovement
{
    private ChessPiece _piece { get; set; }
    private ChessSquare _target { get; set; }

    public ChessMovementBase(ChessPiece piece, ChessSquare target)
    {
        _piece = piece;
        _target = target;
    }

    public override void ApplyMovement(ChessBoard board)
    {
        /*if (!IsSourceSquareValid(_source))
            throw new NullReferenceException("Source square is empty");

        _source.Piece.MoveToNewSquare(_target, this);*/
    }
}