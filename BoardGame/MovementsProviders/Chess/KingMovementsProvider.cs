using System.Collections.Generic;
using BoardGame.Board;
using BoardGame.Game;
using BoardGame.SquaresLocation.Links;
using BoardGame.SquaresLocation.Links._2DGrid;
using BoardGame.Movements;
using BoardGame.Movements.Chess;
using BoardGame.Pieces;
using BoardGame.Pieces.Visitors;

namespace BoardGame.MovementsProviders.Chess;

public class KingMovementsProvider : ChessMovementsProvider
{
    public KingMovementsProvider(IGame game, IBoard board, IPiece piece) : base(game, board, piece)
    {
    }
    
    public List<IMovement> GetAvailableMoves()
    {
        var moves = new List<IMovement>();

        //All directions, one square move
        foreach (var link in StraightLinks) AddMoveIfPossible(moves, link);
        foreach (var link in DiagonalLinks) AddMoveIfPossible(moves, link);

        //Rock
        AddRockIfPossible(moves);
        AddBigRockIfPossible(moves);

        return moves;
    }

    private void AddMoveIfPossible(List<IMovement> moves, ISquareLink link)
    {
        var links = new Link2DGridBuilder().Link(link).Build();
        if (TryGetSquareEmptyOrWithOpponent(links, out var square))
            moves.Add(new ChessMovementBase(Piece, square));
    }

    private void AddRockIfPossible(List<IMovement> moves)
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
        moves.Add(new ChessMovementRock(Piece, kingTarget, tower, towerTarget));
    }

    private void AddBigRockIfPossible(List<IMovement> moves)
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
        moves.Add(new ChessMovementRock(Piece!, kingTarget, tower!, towerTarget));
    }
}