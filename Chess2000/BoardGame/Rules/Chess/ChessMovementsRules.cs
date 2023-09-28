using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Game.Chess;
using Chess2000.BoardGame.Location.Chess;
using Chess2000.BoardGame.Movement;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Rules.Chess;

public class ChessMovementsRules : MovementsRules<ChessPiece>
{
    public ChessMovementsRules(IGame<ChessPiece> game, IBoard board, ChessPiece piece) : base(game, board, piece)
    {
    }

    public List<IMovement> GetAvailableMoves(BlackPawn blackPawn)
    {
        var movementProvider = new PawnMovementsProvider(Game, Board, Piece);
        return movementProvider.GetAvailableMoves(blackPawn);
    }

    public List<IMovement> GetAvailableMoves(WhitePawn whitePawn)
    {
        var movementProvider = new PawnMovementsProvider(Game, Board, Piece);
        return movementProvider.GetAvailableMoves(whitePawn);
    }
}