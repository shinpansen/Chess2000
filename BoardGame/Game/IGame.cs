using BoardGame.SquaresLocation;
using BoardGame.Movements;
using BoardGame.Pieces;
using BoardGame.Board;
using BoardGame.Players;
using System.Collections.ObjectModel;

namespace BoardGame.Game;

public interface IGame
{
    public ReadOnlyCollection<IPlayer> GetAvailablePlayers();
    public bool TryGetPiece(ISquareLocation location, out IPiece piece);
    public void VerifyMove(IPiece piece, IMovement move, IBoard board);
    public void ExecuteMove(IPiece piece, IMovement move, IBoard board);
}
