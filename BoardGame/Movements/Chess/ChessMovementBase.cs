using System;
using System.Collections.Generic;
using System.Linq;
using BoardGame.Board.Chess;
using BoardGame.Game;
using BoardGame.SquaresLocation;
using BoardGame.Pieces;
using BoardGame.Pieces.Chess;
using BoardGame.MovementsRules;
using BoardGame.Squares;
using BoardGame.Squares.Chess;

namespace BoardGame.Movements.Chess;

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
        piecesClone.Add(Piece.Clone(Target, this));

        return piecesClone;
    }

    public virtual bool Equals(IMovement? other)
    {
        if (other is not ChessMovementBase otherMovement) return false;
        return otherMovement.Piece.Equals(this.Piece) && 
            otherMovement.Target.GetLocation().Equals(this.Target.GetLocation());
    }
}