using System.Collections.Generic;
using BoardGame.Board;
using BoardGame.Game;
using BoardGame.SquaresLocation.Links;
using BoardGame.SquaresLocation.Links._2DGrid;
using BoardGame.Movements;
using BoardGame.Movements.Chess;
using BoardGame.Pieces;
using BoardGame.Pieces.Visitors;
using BoardGame.Pieces.Chess;

namespace BoardGame.MovementsProviders.Chess;

public class KingMovementsProvider : ChessMovementsProvider
{
    public KingMovementsProvider(IGame game, IBoard board, IPiece piece) : base(game, board, piece)
    {
        //All directions, one square move
        var possibleLinks = DiagonalLinks.Concat(StraightLinks).ToList();
        foreach (var link in possibleLinks) AddMoveIfPossibleAndNotThreateningOtherKing(link, possibleLinks);

        //Rock
        AddRockIfPossible();
        AddBigRockIfPossible();
    }

    private void AddMoveIfPossibleAndNotThreateningOtherKing(ISquareLink link, List<ISquareLink> possibleLinks)
    {
        var firstMoveLink = new Link2DGridBuilder().Link(link).Build();
        if (!TryGetSquareEmptyOrWithOpponent(firstMoveLink, out var firstSquare)) return;

        //A king can't directly threaten another king.
        //We simulate the next move to see if we can eat another king from the firstSquare spot
        foreach (var secondLink in possibleLinks)
        {
            var secondMoveLink = new Link2DGridBuilder().Link(link).Link(secondLink).Build();
            if (TryGetSquareWithOpponent(secondMoveLink, out var squareNextMove) &&
                TryGetPiece(squareNextMove.GetLocation(), out var piece) &&
                piece is King)
                return;
        }

        Moves.Add(new ChessMovementBase(Piece, firstSquare));
    }

    private void AddRockIfPossible()
    {
        //King must never have moved
        if (Piece.Visit(new MovementPieceVisitor()) is not null) return;

        //Path should be free
        if (!TryGetEmptySquare(new Link2DGridBuilder().Right().Right().Build(), out var kingTarget, true)) return;

        //Tower must never have moved
        if (!TryGetSquare(new Link2DGridBuilder().Right().Right().Right().Build(), out var towerSquare)) return;
        if (!TryGetPiece(towerSquare.GetLocation(), out var tower)) return;
        if (tower.Visit(new MovementPieceVisitor()) is not null) return;

        TryGetEmptySquare(new Link2DGridBuilder().Right().Build(), out var towerTarget);
        Moves.Add(new ChessMovementRock(Piece, kingTarget, tower, towerTarget));
    }

    private void AddBigRockIfPossible()
    {
        //King must never have moved
        if (Piece?.Visit(new MovementPieceVisitor()) is not null) return;

        //Path should be free for king and tower
        if (!TryGetEmptySquare(new Link2DGridBuilder().Left().Left().Build(), out var kingTarget, true)) return;
        if (!TryGetSquare(new Link2DGridBuilder().Left().Left().Left().Build(), out _, true)) return;

        //Tower must never have moved
        if (!TryGetSquare(new Link2DGridBuilder().Left().Left().Left().Left().Build(), out var towerSquare)) return;
        if (!TryGetPiece(towerSquare.GetLocation(), out var tower)) return;
        if (tower?.Visit(new MovementPieceVisitor()) is not null) return;

        TryGetEmptySquare(new Link2DGridBuilder().Left().Build(), out var towerTarget);
        Moves.Add(new ChessMovementRock(Piece!, kingTarget, tower!, towerTarget));
    }
}