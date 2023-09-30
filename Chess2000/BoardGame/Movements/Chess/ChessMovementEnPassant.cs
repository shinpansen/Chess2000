using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Movements.Chess;

public class ChessMovementEnPassant : IMovement
{
    private IPiece _pawn { get; set; }
    private ISquare _pawnTarget { get; set; }
    private IPiece _otherPiece { get; set; }

    public ChessMovementEnPassant(IPiece pawn, ISquare pawnTarget, IPiece otherPiece)
    {
        _pawn = pawn;
        _pawnTarget = pawnTarget;
        _otherPiece = otherPiece;
    }

    public List<IPiece> SimulateMove(IGame game)
    {
        var piecesClone = new List<IPiece>(game.GetAvailablePieces());

        piecesClone.Remove(_pawn);
        piecesClone.Add(_pawn.Clone(_pawnTarget, new Data.Data("LastMove", this)));
        piecesClone.Remove(_otherPiece);

        return piecesClone;
    }
}