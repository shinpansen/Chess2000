using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Location.Chess;
using Chess2000.BoardGame.Movement;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Rules.Chess;

public class ChessMovementRules : IMovementRules
{
    private IGame _game { get; set; }
    private IPiece _piece { get; set; }

    public List<IMovement> GetAvailableMoves(IGame game, IPiece piece)
    {
        _game = game;
        _piece = piece;
        
        return _piece.GetAvailableMovements(this);
    }

    public List<IMovement> GetAvailableMoves(BlackPawn blackPawn)
    {
        var movementProvider = new PawnMovementProvider(_piece, _piecesController, _board);
        return movementProvider.GetAvailableMoves(blackPawn);
    }

    public List<IMovement> GetAvailableMoves(WhitePawn whitePawn)
    {
        var movementProvider = new PawnMovementProvider(_piece, _piecesController, _board);
        return movementProvider.GetAvailableMoves(whitePawn);
    }
}