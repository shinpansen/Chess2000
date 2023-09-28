using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares.Chess;
using Chess2000.BoardGame.Game.Chess;
using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Movement;
using Chess2000.BoardGame.Location.Links;
using Chess2000.BoardGame.Location.Links._2DGrid;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Pieces;

namespace Chess2000.BoardGame.Rules.Chess;

public class PawnMovementsProvider : ChessMovementsProvider
{
    public PawnMovementsProvider(IGame<ChessPiece> game, IBoard board, ChessPiece piece) : base(game, board, piece)
    {
    }

    public List<IMovement> GetAvailableMoves(BlackPawn pawn)
    {
        return GetAvailableMoves(new Bottom());
    }

    public List<IMovement> GetAvailableMoves(WhitePawn pawn)
    {
        return GetAvailableMoves(new Top());
    }

    private List<IMovement> GetAvailableMoves(ISquareLink link)
    {
        var moves = new List<IMovement>();

        //Basic forward move
        var forwardLinks = new Queue<ISquareLink>();
        forwardLinks.Enqueue(link);
        if (TryGetEmptySquare(forwardLinks, out var square))
            moves.Add(new ChessMovementBase(Piece, square));

        //Eating opponent on the left
        var DiagonaleLeftLinks = new Queue<ISquareLink>();
        DiagonaleLeftLinks.Enqueue(link);
        DiagonaleLeftLinks.Enqueue(new Left());
        if (TryGetSquareWithOpponent(DiagonaleLeftLinks, out var square2)) 
            moves.Add(new ChessMovementBase(Piece, square2));

        //Eating opponent on the right
        var DiagonaleRightLinks = new Queue<ISquareLink>();
        DiagonaleRightLinks.Enqueue(link);
        DiagonaleRightLinks.Enqueue(new Right());
        if (TryGetSquareWithOpponent(DiagonaleRightLinks, out var square3))
            moves.Add(new ChessMovementBase(Piece, square3));

        return moves;
    }
}