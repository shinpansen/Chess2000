using BoardGame.Board;
using BoardGame.Game;
using BoardGame.Movements;
using BoardGame.MovementsProviders;
using BoardGame.MovementsProviders.Chess;
using BoardGame.Squares;
using BoardGame.SquaresLocation.Links._2DGrid;
using System;
using System.Collections.Generic;
using BoardGame.Movements.Chess;
using BoardGame.SquaresLocation.Links;

namespace BoardGame.Pieces.Chess;

public sealed class Pawn : ChessPiece
{
    private ISquareLink _forward { get; set; }
    
    private Pawn(ISquare square, ISquareLink forward) : base(square)
    {
        _forward = forward;
    }

    private Pawn(ISquare square, IMovement? lastMove, ISquareLink forward) : base(square, lastMove)
    {
        _forward = forward;
    }

    public Pawn(string location, ISquareLink forward) : base(location)
    {
        _forward = forward;
    }

    public override List<IMovement> GetAvailableMoves(IGame game)
    {
        var provider = new PawnMovementsProvider(game, game.Board, this, _forward);
        return provider.GetAvailableMoves();
    }

    public override List<IMovement> SimulateAvailableMoves(IGame game, IBoard board)
    {
        var provider = new PawnMovementsProvider(game, board, this, _forward);
        return provider.SimulateAvailableMoves();
    }

    public override IPiece Clone()
    {
        return new Pawn(Square, _forward);
    }

    public override IPiece Clone(ISquare newSquare)
    {
        return new Pawn(newSquare, _forward);
    }

    public override IPiece Clone(ISquare newSquare, IMovement? lastMove)
    {
        return new Pawn(newSquare, lastMove, _forward);
    }

    public override bool Equals(IPiece? other)
    {
        if (other is not Pawn otherPiece) return false;
        return otherPiece.Location.Equals(Square.GetLocation()) && 
               otherPiece._forward.Equals(this._forward);
    }

    public override string ToString()
    {
        return "P";
    }
}