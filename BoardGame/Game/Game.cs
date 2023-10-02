using BoardGame.SquaresLocation;
using BoardGame.Movements;
using BoardGame.Pieces;
using BoardGame.Pieces.Chess;
using BoardGame.MovementsProviders;
using BoardGame.MovementsProviders.Chess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGame.Board;

namespace BoardGame.Game;

public abstract class Game : IGame
{
    protected List<IPiece> AvailablePieces { get; set; } = new();

    public ReadOnlyCollection<IPiece> GetAvailablePieces()
    {
        return AvailablePieces.AsReadOnly();
    }

    public bool TryGetPiece(ISquareLocation location, out IPiece piece)
    {
        piece = AvailablePieces.FirstOrDefault(p => p.GetSquare().GetLocation().Equals(location));
        return piece is not null;
    }

    public void VerifyMove(IPiece piece, IMovement move, IBoard board)
    {
        var moves = piece.GetAvailableMoves(this, board);
        if (!moves.Any(m => m.Equals(move)))
            throw new ArgumentException("Unauthorized move.");
    }

    public void ExecuteMove(IPiece piece, IMovement move, IBoard board)
    {
        VerifyMove(piece, move, board);
        AvailablePieces = move.SimulateMove(this);
    }
}
