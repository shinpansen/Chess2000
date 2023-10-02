using System;
using System.Collections.Generic;
using System.Linq;
using BoardGame.Movements.Chess;
using BoardGame.Pieces.Visitors;
using BoardGame.Board;
using BoardGame.Movements;
using BoardGame.SquaresLocation.Links;
using BoardGame.SquaresLocation.Links._2DGrid;
using BoardGame.Game;
using BoardGame.Pieces;

namespace BoardGame.MovementsProviders.Chess;

public class PawnMovementsProvider : ChessMovementsProvider
{
    public PawnMovementsProvider(IGame game, IBoard board, IPiece piece) : base(game, board, piece)
    {
    }

    public List<IMovement> GetAvailableMoves(ISquareLink forward)
    {
        var moves = new List<IMovement>();

        //Basic forward move
        var forwardLinks = new Link2DGridBuilder().Link(forward).Build();
        if (TryGetEmptySquare(forwardLinks, out var square))
            moves.Add(new ChessMovementBase(Piece, square));

        //Double forward move
        var lastMove = Piece.Visit(new MovementPieceVisitor());
        if (lastMove is null) //Only allowed for the first move
        {
            var doubleForwardLinks = new Link2DGridBuilder().Link(forward).Link(forward).Build();
            if (TryGetEmptySquare(doubleForwardLinks, out var squareDouble, true))
                moves.Add(new ChessMovementPawnDouble(Piece, squareDouble));
        }

        //Eating opponent on the left
        var topLeftLinks = new Link2DGridBuilder().Link(forward).Left().Build();
        if (TryGetSquareWithOpponent(topLeftLinks, out var squareTopLeft))
            moves.Add(new ChessMovementBase(Piece, squareTopLeft));

        //Eating opponent on the right
        var topRightLinks = new Link2DGridBuilder().Link(forward).Right().Build();
        if (TryGetSquareWithOpponent(topRightLinks, out var squareTopRight))
            moves.Add(new ChessMovementBase(Piece, squareTopRight));
        
        //Prise en passant
        AddPriseEnPassantMove(moves, forward, new Left());
        AddPriseEnPassantMove(moves, forward, new Right());

        return moves;
    }

    private void AddPriseEnPassantMove(List<IMovement> moves, ISquareLink forward, ISquareLink leftRight)
    {
        var enPassantLinks = new Link2DGridBuilder().Link(forward).Link(leftRight).Build();
        var enPassantOpponentLinks = new Link2DGridBuilder().Link(leftRight).Build();
        
        if (!TryGetEmptySquare(enPassantLinks, out var squareEnPassant)) return;
        if (!TryGetSquareWithOpponent(enPassantOpponentLinks, out var squareEnPassantOpponent)) return;

        Game.TryGetPiece(squareEnPassantOpponent.GetLocation(), out var opponentPiece);
        var opponentLastMove = opponentPiece.Visit(new MovementPieceVisitor());
        if(opponentLastMove is ChessMovementPawnDouble)
            moves.Add(new ChessMovementEnPassant(Piece, squareEnPassant, opponentPiece));
    }
}