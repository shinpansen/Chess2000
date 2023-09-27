using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Location.Links;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;
using System.Collections.Generic;
using System.Linq;

namespace Chess2000.BoardGame.Rules.Chess;

public abstract class ChessMovementProvider
{
    private IBoard _board { get; set; }
    private IGame _game { get; set; }
    private IPiece _piece { get; set; }

    protected ChessMovementProvider(IGame game, IBoard board, IPiece piece)
    {
        _game = game;
        _board = board;
        _piece = piece;
    }

    protected bool TryGetEmptySquare(Queue<ISquareLink> links, out ISquare target)
    {
        target = default;

        var location = _piece.GetSquare().GetLocation();
        while (links.Any() && location.GetNeighbors().Any(l => l.Key == links.First()))
        {
            location = location.GetNeighbors().First(l => l.Key == links.First()).Value;
            links.Dequeue();
        }
        if (links.Any()) return false;

        if (!_game.GetAvailablePieces().Any(p => p.GetSquare().GetLocation().Equals(location)))
        {
            target = _board.GetSquare(location);
            return true;
        }
        return false;
    }

    protected bool TryGetSquareWithOpponent(int col, int row, out ChessSquare target)
    {
        target = default;
        if (!Board.TryGetSquareFromCoords(col, row, out var square)) return false;
        var piece = PiecesController.Pieces.FirstOrDefault(p => p.Square._location.Equals(square._location));
        return piece is not null && !IsFriend(piece);
    }

    protected bool TryGetSquareEmptyOrWithOpponent(int col, int row, out ChessSquare target)
    {
        target = default;
        if (!Board.TryGetSquareFromCoords(col, row, out var square)) return false;
        var piece = PiecesController.Pieces.FirstOrDefault(p => p.Square._location.Equals(square._location));
        return piece is null || (piece is not null && !IsFriend(piece));
    }

    protected bool IsFriend(ChessPiece piece)
    {
        return _piece.IsFriend(new ChessPieceColorVisitor(piece));
    }
}