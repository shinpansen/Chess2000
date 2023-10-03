using BoardGame.Movements;
using BoardGame.Pieces.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Pieces.Visitors;

public class MovementPieceVisitor
{
    public MovementPieceVisitor()
    {
    }

    public IMovement? Visit(ChessPiece piece) => piece.LastMove;
}
