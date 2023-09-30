using System;
using System.Collections.Generic;
using System.Linq;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Location;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Movements.Chess;

public class ChessMovementBase : IMovement
{
    protected IPiece Piece { get; set; }
    protected ISquare Target { get; set; }

    public ChessMovementBase(IPiece piece, ISquare target)
    {
        Piece = piece;
        Target = target;
    }

    public List<IPiece> SimulateMove(IGame game)
    {
        var piecesClone = new List<IPiece>(game.GetAvailablePieces());

        if (game.TryGetPiece(Target.GetLocation(), out var targetPiece))
            piecesClone.Remove(targetPiece);

        piecesClone.Remove(Piece);
        piecesClone.Add(Piece.Clone(Target, new Data.Data("LastMove", this)));

        return piecesClone;
    }
}