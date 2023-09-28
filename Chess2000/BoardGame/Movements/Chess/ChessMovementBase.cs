using System;
using System.Collections.Generic;
using System.Linq;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Location;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Movements.Chess;

public class ChessMovementBase : Movement
{
    protected IPiece Piece { get; set; }
    protected ISquare Target { get; set; }

    public ChessMovementBase(IPiece piece, ISquare target)
    {
        Piece = piece;
        Target = target;
    }

    public override List<IPiece> ExecuteMove(IGame game, IMovementsRules rules)
    {
        List<IPiece> piecesClone = CloneAvailablePieces(game);

        if(TryGetPiece(piecesClone, Target.GetLocation(), out var targetPiece))
            piecesClone.Remove(targetPiece);

        if (TryGetPiece(piecesClone, Piece.GetSquare().GetLocation(), out var sourcePiece))
        {
            piecesClone.Add(sourcePiece.Clone(Target));
            piecesClone.Remove(sourcePiece);
        }

        return piecesClone;
    }
}