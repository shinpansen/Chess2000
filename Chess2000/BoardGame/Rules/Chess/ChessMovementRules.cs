using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Rules.Chess;

public class ChessMovementRules : 
    IMovementRules<ChessBoard, ChessPiece, ChessSquare, ChessSquareLocation, ChessMovement, ChessMovementRules, ChessPiecesController, string>
{
    private ChessPiece _piece { get; set; }
    private ChessPiecesController _piecesController { get; set; }
    private ChessBoard _board { get; set; }

    public ChessMovementRules(ChessPiece piece, ChessPiecesController piecesController, ChessBoard board)
    {
        _piece = piece;
        _piecesController = piecesController;
        _board = board;
    }

    public Dictionary<string, ChessMovement> GetAvailableMoves()
    {
        if(_piece is null) new List<ChessMovement>();
        
        return _piece.GetAvailableMovements(this);
    }

    public Dictionary<string, ChessMovement> GetAvailableMoves(BlackPawn blackPawn)
    {
        var movementProvider = new PawnMovementProvider(_piece, _piecesController, _board);
        return movementProvider.GetAvailableMoves(blackPawn);
    }

    public Dictionary<string, ChessMovement> GetAvailableMoves(WhitePawn whitePawn)
    {
        var movementProvider = new PawnMovementProvider(_piece, _piecesController, _board);
        return movementProvider.GetAvailableMoves(whitePawn);
    }
}