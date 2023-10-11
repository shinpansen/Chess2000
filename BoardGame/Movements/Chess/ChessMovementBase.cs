using System;
using System.Collections.Generic;
using System.Linq;
using BoardGame.Board.Chess;
using BoardGame.Game;
using BoardGame.SquaresLocation;
using BoardGame.Pieces;
using BoardGame.Pieces.Chess;
using BoardGame.MovementsProviders;
using BoardGame.Squares;
using BoardGame.Squares.Chess;
using BoardGame.Players;

namespace BoardGame.Movements.Chess;

public class ChessMovementBase : IMovement
{
    public ISquareLocation? TargetLocation => Target.GetLocation();

    protected IPiece Piece;
    protected ISquare Target;

    public ChessMovementBase(IPiece piece, ISquare target)
    {
        Piece = piece;
        Target = target;
    }

    public virtual List<IPiece> SimulateMove(IGame game, IPlayer player)
    {
        var piecesClone = new List<IPiece>(player.GetAvailablePieces());

        if (!player.TryGetPiece(Piece.Location, out _)) return piecesClone;
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