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
        var provider = new PawnMovementsProvider(Game, Board, Piece);
        return provider.GetAvailableMovesForBlackPawn();
    }

    public List<IMovement> GetAvailableMoves(WhitePawn whitePawn)
    {
        var provider = new PawnMovementsProvider(Game, Board, Piece);
        return provider.GetAvailableMovesForWhitePawn();
    }

    public List<IMovement> GetAvailableMoves(BlackBishop blackBishop)
    {
        var provider = new QueenTowerBishopMovementsProvider(Game, Board, Piece);
        return provider.GetAvailableMoves(ChessMovementsProvider.DiagonalLinks);
    }

    public List<IMovement> GetAvailableMoves(WhiteBishop blackBishop)
    {
        var provider = new QueenTowerBishopMovementsProvider(Game, Board, Piece);
        return provider.GetAvailableMoves(ChessMovementsProvider.DiagonalLinks);
    }

    public List<IMovement> GetAvailableMoves(BlackTower blackTower)
    {
        var provider = new QueenTowerBishopMovementsProvider(Game, Board, Piece);
        return provider.GetAvailableMoves(ChessMovementsProvider.StraightLinks);
    }

    public List<IMovement> GetAvailableMoves(WhiteTower whiteTower)
    {
        var provider = new QueenTowerBishopMovementsProvider(Game, Board, Piece);
        return provider.GetAvailableMoves(ChessMovementsProvider.StraightLinks);
    }

    public List<IMovement> GetAvailableMoves(BlackQueen blackQueen)
    {
        var provider = new QueenTowerBishopMovementsProvider(Game, Board, Piece);
        return provider.GetAvailableMoves(ChessMovementsProvider.StraightLinks, ChessMovementsProvider.DiagonalLinks);
    }

    public List<IMovement> GetAvailableMoves(WhiteQueen whiteQueen)
    {
        var provider = new QueenTowerBishopMovementsProvider(Game, Board, Piece);
        return provider.GetAvailableMoves(ChessMovementsProvider.StraightLinks, ChessMovementsProvider.DiagonalLinks);
    }

    public List<IMovement> GetAvailableMoves(BlackKing blackKing)
    {
        var provider = new KingMovementsProvider(Game, Board, Piece);
        return provider.GetAvailableMoves();
    }

    public List<IMovement> GetAvailableMoves(WhiteKing whiteKing)
    {
        var provider = new KingMovementsProvider(Game, Board, Piece);
        return provider.GetAvailableMoves();
    }

    public List<IMovement> GetAvailableMoves(BlackKnight blackKnight)
    {
        var provider = new KnightMovementsProvider(Game, Board, Piece);
        return provider.GetAvailableMoves();
    }

    public List<IMovement> GetAvailableMoves(WhiteKnight whiteKnight)
    {
        var provider = new KnightMovementsProvider(Game, Board, Piece);
        return provider.GetAvailableMoves();
    }
}