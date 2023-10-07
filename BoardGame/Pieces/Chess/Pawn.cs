using BoardGame.Board;
using BoardGame.Game;
using BoardGame.Movements;
using BoardGame.MovementsProviders;
using BoardGame.MovementsProviders.Chess;
using BoardGame.Squares;
using BoardGame.SquaresLocation.Links._2DGrid;
using System;
using System.Collections.Generic;
using BoardGame.SquaresLocation.Links;

namespace BoardGame.Pieces.Chess;

public sealed class Pawn : ChessPiece
{
    public ISquareLink Forward { get; private set; }
    
    private Pawn(ISquare square, ISquareLink forward) : base(square)
    {
        Forward = forward;
    }

    private Pawn(ISquare square, IMovement? lastMove, ISquareLink forward) : base(square, lastMove)
    {
        Forward = forward;
    }

    public Pawn(string location, ISquareLink forward) : base(location)
    {
        Forward = forward;
    }

    public override List<IMovement> GetAvailableMoves(IGame game)
    {
        var provider = new PawnMovementsProvider(game, game.Board, this, Forward);
        return provider.GetAvailableMoves();
    }

    public override List<IMovement> SimulateAvailableMoves(IGame game, IBoard board)
    {
        var provider = new PawnMovementsProvider(game, board, this, Forward);
        return provider.SimulateAvailableMoves();
    }

    public override IPiece Clone()
    {
        return new Pawn(Square, Forward);
    }

    public override IPiece Clone(ISquare newSquare)
    {
        return new Pawn(newSquare, Forward);
    }

    public override IPiece Clone(ISquare newSquare, IMovement? lastMove)
    {
        return new Pawn(newSquare, lastMove, Forward);
    }

    public override bool Equals(IPiece? other)
    {
        if (other is not Pawn otherPiece) return false;
        return otherPiece.Location.Equals(Square.GetLocation()) && 
               otherPiece.Forward.Equals(this.Forward);
    }

    public override string ToString()
    {
        return "P";
    }
}