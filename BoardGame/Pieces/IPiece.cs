using BoardGame.Board;
using BoardGame.Data;
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

namespace BoardGame.Pieces;

public interface IPiece : ICloneablePiece<IPiece, ISquare, IMovement>, IEquatable<IPiece>
{
    public List<IMovement> GetAvailableMoves(IGame game, IBoard board);
    public ISquare GetSquare();
    public bool Visit(BooleanPieceVisitor visitor);
    public IMovement Visit(MovementPieceVisitor visitor);
}
