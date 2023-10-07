using BoardGame.Board;
using BoardGame.Movements;
using BoardGame.Pieces.Visitors;
using BoardGame.MovementsProviders;
using BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGame.Game;
using BoardGame.SquaresLocation;

namespace BoardGame.Pieces;

public interface IPiece : ICloneablePiece<IPiece, ISquare, IMovement>, IEquatable<IPiece>
{
    public ISquareLocation Location { get; }
    public List<IMovement> GetAvailableMoves(IGame game);
    public List<IMovement> SimulateAvailableMoves(IGame game, IBoard board);
    public ISquare GetSquare();
    public IMovement? Visit(MovementPieceVisitor visitor);
}
