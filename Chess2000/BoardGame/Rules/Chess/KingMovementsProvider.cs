using System.Collections.Generic;
using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Location.Links;
using Chess2000.BoardGame.Location.Links._2DGrid;
using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Movements.Chess;
using Chess2000.BoardGame.Pieces;

namespace Chess2000.BoardGame.Rules.Chess;

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