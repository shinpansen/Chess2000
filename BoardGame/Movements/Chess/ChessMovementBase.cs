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
    protected IPiece Piece { get; set; }
    protected ISquare Target { get; set; }

    public ChessMovementBase(IPiece piece, ISquare target)
    {
        Piece = piece;
        Target = target;
    }

    public List<IPiece> SimulateMove(IGame game, IPlayer player)
    {
        var piecesClone = new List<IPiece>(player.GetAvailablePieces());

        //Eating target
        var targetPiece = piecesClone.FirstOrDefault(p => p.GetSquare().GetLocation().Equals(Target.GetLocation()));
        if (targetPiece is not null) piecesClone.Remove(targetPiece);

        if (game.TryGetPiece(Piece.GetSquare().GetLocation(), out _))
        {
            piecesClone.Remove(Piece);
            piecesClone.Add(Piece.Clone(Target, this));
        }

        return piecesClone;
    }

    public virtual bool Equals(IMovement? other)
    {
        if (other is not ChessMovementBase otherMovement) return false;
        return otherMovement.Piece.Equals(this.Piece) && 
            otherMovement.Target.GetLocation().Equals(this.Target.GetLocation());
    }
}