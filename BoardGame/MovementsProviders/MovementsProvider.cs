using BoardGame.Board;
using BoardGame.Game;
using BoardGame.SquaresLocation.Links;
using BoardGame.Pieces;
using BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGame.SquaresLocation;
using BoardGame.Movements;

namespace BoardGame.MovementsProviders;

public abstract class MovementsProvider : IMovementProvider
{
    protected IGame Game { get; set; }
    protected IBoard Board { get; set; }
    protected IPiece Piece { get; set; }

    protected MovementsProvider(IGame game, IBoard board, IPiece piece)
    {
        Game = game;
        Board = board;
        Piece = piece;
    }

    public virtual bool TryGetSquare(Queue<ISquareLink> links, out ISquare square, bool pathShouldBeFree = false)
    {
        square = default;

        var location = Piece.Location;
        while (links.Any() && location.GetNeighbors().Any(l => l.Key.Equals(links.First())))
        {
            location = location.GetNeighbors().First(l => l.Key.Equals(links.First())).Value;
            if (pathShouldBeFree && TryGetPiece(location, out _)) return false;
            links.Dequeue();
        }
        if (links.Any()) return false;

        square = Board.GetSquare(location);
        return true;
    }

    public virtual bool TryGetPiece(ISquareLocation location, out IPiece piece)
    {
        piece = default;
        foreach (var player in Game.GetAvailablePlayers())
            if (player.TryGetPiece(location, out piece))
                return true;
        return false;
    }

    public abstract List<IMovement> GetAvailableMoves();
    public abstract List<IMovement> SimulateAvailableMoves();
}
