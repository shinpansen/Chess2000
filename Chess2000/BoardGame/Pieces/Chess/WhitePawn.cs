using System.Collections.Generic;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public class WhitePawn : WhitePiece
{
    public WhitePawn(ChessSquare square) : base(square)
    {
    }
    
    public override Dictionary<string, ChessMovement> GetAvailableMovements(ChessMovementRules rules)
    {
        return rules.GetAvailableMoves(this);
    }
}