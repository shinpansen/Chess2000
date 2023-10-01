using BoardGame.Board;
using BoardGame.Game;
using BoardGame.Location.Links;
using BoardGame.Pieces;
using BoardGame.Pieces.Visitors;
using BoardGame.Squares;
using System.Collections.Generic;
using System.Linq;
using BoardGame.Location.Links._2DGrid;

namespace BoardGame.Rules.Chess;

public abstract class ChessMovementsProvider : MovementsProvider
{
    protected static readonly List<ISquareLink> StraightLinks = new List<ISquareLink>()
    {
        new Top(),
        new Bottom(),
        new Left(),
        new Right()
    };
    
    protected static readonly List<ISquareLink> DiagonalLinks = new List<ISquareLink>()
    {
        new TopLeft(),
        new BottomLeft(),
        new TopRight(),
        new BottomRight()
    };
    
    protected ChessMovementsProvider(IGame game, IBoard board, IPiece piece) : base(game, board, piece)
    {
    }

    protected bool TryGetEmptySquare(Queue<ISquareLink> links, out ISquare square, bool pathShouldBeFree = false)
    {
        if(!TryGetSquare(links, out square, pathShouldBeFree)) return false;

        var targetLocation = square.GetLocation();
        return !Game.GetAvailablePieces().Any(p => p.GetSquare().GetLocation().Equals(targetLocation));
    }

    protected bool TryGetSquareWithOpponent(Queue<ISquareLink> links, out ISquare square, bool pathShouldBeFree = false)
    {
        if (!TryGetSquare(links, out square, pathShouldBeFree)) return false;

        var targetLocation = square.GetLocation();
        var piece = Game.GetAvailablePieces().FirstOrDefault(p => p.GetSquare().GetLocation().Equals(targetLocation));
        return piece is not null && !IsFriend(piece);
    }

    protected bool TryGetSquareEmptyOrWithOpponent(Queue<ISquareLink> links, out ISquare square, bool pathShouldBeFree = false)
    {
        if (!TryGetSquare(links, out square, pathShouldBeFree)) return false;

        var targetLocation = square.GetLocation();
        var piece = Game.GetAvailablePieces().FirstOrDefault(p => p.GetSquare().GetLocation().Equals(targetLocation));
        return piece is null || !IsFriend(piece);
    }

    private bool IsFriend(IPiece piece)
    {
        return Piece.Visit(new BooleanPieceVisitor(piece));
    }
}