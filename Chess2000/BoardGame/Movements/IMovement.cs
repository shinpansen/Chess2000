using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Location;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Rules;
using System.Collections.Generic;

namespace Chess2000.BoardGame.Movements;

public interface IMovement
{
    public List<IPiece> CloneAvailablePieces(IGame game);
    public bool TryGetPiece(List<IPiece> availablePieces, ISquareLocation location, out IPiece piece);
    public List<IPiece> ExecuteMove(IGame game, IMovementsRules rules);
}