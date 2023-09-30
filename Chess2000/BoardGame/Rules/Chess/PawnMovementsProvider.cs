using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Movements.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares.Chess;
using Chess2000.BoardGame.Game.Chess;
using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Location.Links;
using Chess2000.BoardGame.Location.Links._2DGrid;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Pieces;

namespace Chess2000.BoardGame.Rules.Chess;

public class PawnMovementsProvider : ChessMovementsProvider
{
    public PawnMovementsProvider(IGame game, IBoard board, IPiece piece) : base(game, board, piece)
    {
    }

    public List<IMovement> GetAvailableMovesForBlackPawn()
    {
        return GetAvailableMoves(new Bottom());
    }

    public List<IMovement> GetAvailableMovesForWhitePawn()
    {
        return GetAvailableMoves(new Top());
    }

    private List<IMovement> GetAvailableMoves(ISquareLink forward)
    {
        var moves = new List<IMovement>();

        //Basic forward move
        var forwardLinks = new Link2DGridBuilder().Link(forward).Build();
        if (TryGetEmptySquare(forwardLinks, out var square))
            moves.Add(new ChessMovementBase(Piece, square));

        //Double forward move
        IMovement lastMove = Piece.Visit(new Pieces.Visitors.MovementPieceVisitor(Piece));
        if (lastMove is null) //Only allowed for the first move
        {
            var doubleForwardLinks = new Link2DGridBuilder().Link(forward).Link(forward).Build();
            if (TryGetEmptySquare(doubleForwardLinks, out var squareDouble, true))
                moves.Add(new ChessMovementPawnDouble(Piece, squareDouble));
        }

        //Eating opponent on the left
        var DiagonaleLeftLinks = new Link2DGridBuilder().Link(forward).Left().Build();
        if (TryGetSquareWithOpponent(DiagonaleLeftLinks, out var square2))
            moves.Add(new ChessMovementBase(Piece, square2));

        //Eating opponent on the right
        var DiagonaleRightLinks = new Link2DGridBuilder().Link(forward).Right().Build();
        if (TryGetSquareWithOpponent(DiagonaleRightLinks, out var square3))
            moves.Add(new ChessMovementBase(Piece, square3));

        return moves;
    }
}