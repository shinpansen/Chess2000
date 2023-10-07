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
using BoardGame.Pieces.Chess;

namespace BoardGame.MovementsProviders.Chess;

public class PawnMovementsProvider : ChessMovementsProvider
{
    public PawnMovementsProvider(IGame game, IBoard board, IPiece piece, ISquareLink forward) : base(game, board, piece)
    {
        //Basic forward move
        var forwardLinks = new Link2DGridBuilder().Link(forward).Build();
        if (TryGetEmptySquare(forwardLinks, out var square))
            Moves.Add(new ChessMovementBase(Piece, square));

        //Double forward move
        var lastMove = Piece.Visit(new MovementPieceVisitor());
        if (lastMove is null) //Only allowed for the first move
        {
            var doubleForwardLinks = new Link2DGridBuilder().Link(forward).Link(forward).Build();
            if (TryGetEmptySquare(doubleForwardLinks, out var squareDouble, true))
                Moves.Add(new ChessMovementPawnDouble(Piece, squareDouble));
        }

        //Eating opponent on the left
        var topLeftLinks = new Link2DGridBuilder().Link(forward).Left().Build();
        if (TryGetSquareWithOpponent(topLeftLinks, out var squareTopLeft))
            Moves.Add(new ChessMovementBase(Piece, squareTopLeft));

        //Eating opponent on the right
        var topRightLinks = new Link2DGridBuilder().Link(forward).Right().Build();
        if (TryGetSquareWithOpponent(topRightLinks, out var squareTopRight))
            Moves.Add(new ChessMovementBase(Piece, squareTopRight));

        //Prise en passant
        AddPriseEnPassantMove(forward, new Left());
        AddPriseEnPassantMove(forward, new Right());

        //Super movement (transformation into Queen or other piece)
        if (!TryGetSquare(new Link2DGridBuilder().Link(forward, 2).Build(), out var lastSquare)) //Last square in front
        {
            string lastSquareLocation = lastSquare.GetLocation().ToString() ?? "";
            Moves.Add(new ChessMovementSuper(Piece, lastSquare, new Queen(lastSquareLocation)));
            Moves.Add(new ChessMovementSuper(Piece, lastSquare, new Tower(lastSquareLocation)));
            Moves.Add(new ChessMovementSuper(Piece, lastSquare, new Bishop(lastSquareLocation)));
            Moves.Add(new ChessMovementSuper(Piece, lastSquare, new Knight(lastSquareLocation)));
            Moves.Add(new ChessMovementSuper(Piece, lastSquare, Piece.Clone(lastSquare))); //Stay a pawn!
        }
    }

    private void AddPriseEnPassantMove(ISquareLink forward, ISquareLink leftRight)
    {
        var enPassantLinks = new Link2DGridBuilder().Link(forward).Link(leftRight).Build();
        var enPassantOpponentLinks = new Link2DGridBuilder().Link(leftRight).Build();
        
        if (!TryGetEmptySquare(enPassantLinks, out var squareEnPassant)) return;
        if (!TryGetSquareWithOpponent(enPassantOpponentLinks, out var squareEnPassantOpponent)) return;

        TryGetPiece(squareEnPassantOpponent.GetLocation(), out var opponentPiece);
        var opponentLastMove = opponentPiece.Visit(new MovementPieceVisitor());
        if(opponentLastMove is IChessMovementPawnDouble)
            Moves.Add(new ChessMovementEnPassant(Piece, squareEnPassant, opponentPiece));
    }
}