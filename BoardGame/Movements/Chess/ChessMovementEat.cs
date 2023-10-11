using BoardGame.Game;
using BoardGame.Pieces;
using BoardGame.Players;
using BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Movements.Chess
{
    public class ChessMovementEat : ChessMovementBase
    {
        public ChessMovementEat(IPiece piece, ISquare target) : base(piece, target)
        {
        }

        public override List<IPiece> SimulateMove(IGame game, IPlayer player)
        {
            var piecesClone = base.SimulateMove(game, player);

            if (player.TryGetPiece(Target.GetLocation(), out var targetPiece))
                piecesClone.Remove(targetPiece);

            return piecesClone;
        }

        public override bool Equals(IMovement? other)
        {
            if (other is not ChessMovementEat otherMovement) return false;
            return otherMovement.Piece.Equals(this.Piece) &&
                otherMovement.Target.GetLocation().Equals(this.Target.GetLocation());
        }
    }
}
