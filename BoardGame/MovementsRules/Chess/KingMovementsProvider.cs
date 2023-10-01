using System.Collections.Generic;
using BoardGame.Board;
using BoardGame.Game;
using BoardGame.SquaresLocation.Links;
using BoardGame.SquaresLocation.Links._2DGrid;
using BoardGame.Movements;
using BoardGame.Movements.Chess;
using BoardGame.Pieces;

namespace BoardGame.MovementsRules.Chess;

public class KingMovementsProvider : ChessMovementsProvider
{
    public KingMovementsProvider(IGame game, IBoard board, IPiece piece) : base(game, board, piece)
    {
    }
    
    public List<IMovement> GetAvailableMoves()
    {
        var moves = new List<IMovement>();

        //All directions, one square move
        foreach (var link in StraightLinks) AddAvailableMove(moves, link);
        foreach (var link in DiagonalLinks) AddAvailableMove(moves, link);
        return moves;
    }

    private void AddAvailableMove(List<IMovement> moves, ISquareLink link)
    {
        var links = new Link2DGridBuilder().Link(link).Build();
        if (TryGetSquareEmptyOrWithOpponent(links, out var s))
            moves.Add(new ChessMovementBase(Piece, s));
    }
}