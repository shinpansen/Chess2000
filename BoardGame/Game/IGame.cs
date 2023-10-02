using BoardGame.SquaresLocation;
using BoardGame.Movements;
using BoardGame.Pieces;
using BoardGame.MovementsProviders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGame.Board;

namespace BoardGame.Game;

public interface IGame
{
    public ReadOnlyCollection<IPiece> GetAvailablePieces();
    public bool TryGetPiece(ISquareLocation location, out IPiece piece);
    public void VerifyMove(IPiece piece, IMovement move, IBoard board);
    public void ExecuteMove(IPiece piece, IMovement move, IBoard board);
}
