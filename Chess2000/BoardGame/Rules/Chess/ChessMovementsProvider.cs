using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Game.Chess;
using Chess2000.BoardGame.Location.Links;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;
using System.Collections.Generic;
using System.Linq;

namespace Chess2000.BoardGame.Rules.Chess;

public abstract class ChessMovementsProvider : MovementsProvider<ChessPiece>
{
    protected ChessMovementsProvider(IGame<ChessPiece> game, IBoard board, ChessPiece piece) : base(game, board, piece)
    {
    }

    protected bool TryGetEmptySquare(Queue<ISquareLink> links, out ISquare square)
    {
        if(!TryGetSquare(links, out square)) return false;

        var targetLocation = square.GetLocation();
        if (!Game.GetAvailablePieces().Any(p => p.GetSquare().GetLocation().Equals(targetLocation)))
            return true;
        return false;
    }

    protected bool TryGetSquareWithOpponent(Queue<ISquareLink> links, out ISquare square)
    {
        if (!TryGetSquare(links, out square)) return false;

        var targetLocation = square.GetLocation();
        var piece = Game.GetAvailablePieces().FirstOrDefault(p => p.GetSquare().GetLocation().Equals(targetLocation));
        if (piece is not null && !IsFriend(piece)) return true;
        return false;
    }

    protected bool TryGetSquareEmptyOrWithOpponent(Queue<ISquareLink> links, out ISquare square)
    {
        if (!TryGetSquare(links, out square)) return false;

        var targetLocation = square.GetLocation();
        var piece = Game.GetAvailablePieces().FirstOrDefault(p => p.GetSquare().GetLocation().Equals(targetLocation));
        if (piece is null || (piece is not null && !IsFriend(piece))) return true;
        return false;
    }

    protected bool IsFriend(ChessPiece piece)
    {
        return Piece.IsFriend(new ChessPieceColorVisitor(piece));
    }
}