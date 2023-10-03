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
using BoardGame.Players;

namespace BoardGame.Game;

public abstract class Game : IGame
{
    public abstract bool IsRunning { get; }
    public abstract IBoard Board { get; }

    public virtual void VerifyMove(IPiece piece, IMovement move)
    {
        var moves = piece.GetAvailableMoves(this, Board);
        if (!moves.Any(m => m.Equals(move)))
            throw new ArgumentException("Unauthorized move.");
    }
    
    public abstract ReadOnlyCollection<IPlayer> GetAvailablePlayers();
    public abstract ReadOnlyCollection<IPlayer> GetCurrentPlayers();
    public abstract void ExecuteMove(IPiece piece, IMovement move);
}
