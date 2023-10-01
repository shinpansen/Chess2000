using BoardGame.Board;
using BoardGame.Game;
using BoardGame.SquaresLocation.Links;
using BoardGame.Pieces;
using BoardGame.Pieces.Visitors;
using BoardGame.Squares;
using System.Collections.Generic;
using System.Linq;
using BoardGame.SquaresLocation.Links._2DGrid;

namespace BoardGame.MovementsRules.Chess;

public abstract class ChessMovementsProvider : MovementsProvider
{
    public static readonly List<ISquareLink> StraightLinks = new List<ISquareLink>()
    {
        new Top(),
        new Bottom(),
        new Left(),
        new Right()
    };

    public static readonly List<ISquareLink> DiagonalLinks = new List<ISquareLink>()
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
        return !Game.TryGetPiece(square.GetLocation(), out _);
    }

    protected bool TryGetSquareWithOpponent(Queue<ISquareLink> links, out ISquare square, bool pathShouldBeFree = false)
    {
        if (!TryGetLastSquareEmptyOrWithOpponent(links, out square, out var piece, pathShouldBeFree)) return false;
        return piece is not null && !IsFriend(piece);
    }

    protected bool TryGetSquareEmptyOrWithOpponent(Queue<ISquareLink> links, out ISquare square, bool pathShouldBeFree = false)
    {
        if (!TryGetLastSquareEmptyOrWithOpponent(links, out square, out var piece, pathShouldBeFree)) return false;
        return piece is null || !IsFriend(piece);
    }

    private bool TryGetLastSquareEmptyOrWithOpponent(Queue<ISquareLink> links, out ISquare square, out IPiece piece, bool pathShouldBeFree)
    {
        piece = default;
        //Test if there is an opponent on the last square of the path
        //If pathShouldBeFree is true, we cannot get the last square with a potential opponent
        var linksClone = new Queue<ISquareLink>(links);
        if (!TryGetSquare(links, out square, pathShouldBeFree))
        {
            if (links.Count > 1) return false;
            else if (!TryGetSquare(linksClone, out square)) return false;
        }
        Game.TryGetPiece(square.GetLocation(), out piece);
        return true;
    }

    private bool IsFriend(IPiece piece)
    {
        return Piece.Visit(new BooleanPieceVisitor(piece));
    }
}