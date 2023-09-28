using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Movement.Chess;

public class ChessMovementBase : IMovement
{
    protected IPiece Piece { get; set; }
    protected ISquare Target { get; set; }

    public ChessMovementBase(IPiece piece, ISquare target)
    {
        Piece = piece;
        Target = target;
    }

    public void ExecuteMove(List<IPiece> availablePieces, IMovementsRules rules)
    {
        throw new NotImplementedException();
    }
}