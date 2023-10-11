using BoardGame.SquaresLocation;
using BoardGame.Movements;
using BoardGame.Pieces;
using BoardGame.Board;
using BoardGame.Players;
using System.Collections.ObjectModel;

namespace BoardGame.Game;

public interface IGame
{
    public bool IsRunning { get; }
    public IBoard Board { get; }
    public ReadOnlyCollection<IPlayer> GetAvailablePlayers();
    public ReadOnlyCollection<IPlayer> GetCurrentPlayers();
    public void VerifyMove(IPiece piece, IMovement move);
    public void ExecuteMove(IPiece piece, IMovement move);
    public void OnBeforeTurnStarts(object sender, EventArgs e);
    public void OnAfterTurnEnds(object sender, EventArgs e);
}
