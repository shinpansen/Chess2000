using BoardGame.Board;
using BoardGame.Data;
using BoardGame.Movements;
using BoardGame.Pieces.Visitors;
using BoardGame.MovementsRules;
using BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Pieces;

public interface IPiece : ICloneablePiece<IPiece, ISquare, IMovement>, IEquatable<IPiece>
{
    public List<IMovement> GetAvailableMoves(IMovementsRules rules);
    public ISquare GetSquare();
    public bool Visit(BooleanPieceVisitor visitor);
    public IMovement Visit(MovementPieceVisitor visitor);
}
