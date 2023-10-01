using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using BoardGame.Game;
using BoardGame.Pieces;
using BoardGame.Pieces.Chess;
using BoardGame.Squares;
using BoardGame.Squares.Chess;

namespace BoardGame.Movements.Chess;

public class ChessMovementEnPassant : IMovement
{
    private IPiece _pawn { get; set; }
    private ISquare _pawnTarget { get; set; }
    private IPiece _opponentPiece { get; set; }

    public ChessMovementEnPassant(IPiece pawn, ISquare pawnTarget, IPiece opponentPiece)
    {
        _pawn = pawn;
        _pawnTarget = pawnTarget;
        _opponentPiece = opponentPiece;
    }

    public List<IPiece> SimulateMove(IGame game)
    {
        var piecesClone = new List<IPiece>(game.GetAvailablePieces());

        piecesClone.Remove(_pawn);
        piecesClone.Add(_pawn.Clone(_pawnTarget, this));
        piecesClone.Remove(_opponentPiece);

        return piecesClone;
    }
}