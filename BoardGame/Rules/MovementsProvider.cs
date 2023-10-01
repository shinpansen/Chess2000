using BoardGame.Board;
using BoardGame.Game;
using BoardGame.Location.Links;
using BoardGame.Pieces;
using BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Rules;

public abstract class MovementsProvider : IMovementProvider
{
    protected IBoard Board { get; set; }
    protected IGame Game { get; set; }
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

        var location = Piece.GetSquare().GetLocation();
        while (links.Any() && location.GetNeighbors().Any(l => l.Key.Equals(links.First())))
        {
            location = location.GetNeighbors().First(l => l.Key.Equals(links.First())).Value;
            links.Dequeue();

            if (pathShouldBeFree && Game.TryGetPiece(location, out _)) return false;
        }
        if (links.Any()) return false;

        square = Board.GetSquare(location);
        return true;
    }
}
