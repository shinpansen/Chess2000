using System;
using System.Collections.Generic;
using BoardGame.Board;
using BoardGame.Board.Chess;
using BoardGame.Game;
using BoardGame.Game.Chess;
using BoardGame.SquaresLocation.Chess;
using BoardGame.Movements;
using BoardGame.Movements.Chess;
using BoardGame.Pieces;
using BoardGame.Pieces.Chess;
using BoardGame.MovementsRules;
using BoardGame.Squares.Chess;

namespace BoardGame.MovementsRules.Chess;

public class ChessMovementsRules : MovementsRules
{
    public ChessMovementsRules(IGame game, IBoard board, IPiece piece) : base(game, board, piece)
    {
    }

    public List<IMovement> GetAvailableMoves(BlackPawn blackPawn)
    {
        var movementProvider = new PawnMovementsProvider(Game, Board, Piece);
        return movementProvider.GetAvailableMovesForBlackPawn();
    }

    public List<IMovement> GetAvailableMoves(WhitePawn whitePawn)
    {
        var movementProvider = new PawnMovementsProvider(Game, Board, Piece);
        return movementProvider.GetAvailableMovesForWhitePawn();
    }
}