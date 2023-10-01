using BoardGame.Movements;
using BoardGame.MovementsRules.Chess;
using BoardGame.MovementsRules;
using BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Pieces.Chess
{
    public sealed class BlackBishop : BlackPiece
    {
        public BlackBishop(ISquare square) : base(square)
        {
        }

        public BlackBishop(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public BlackBishop(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
        {
            var provider = new QueenTowerBishopMovementsProvider(rules, this);
            return provider.GetAvailableMoves(ChessMovementsProvider.DiagonalLinks);
        }

        public override IPiece Clone()
        {
            return new BlackBishop(Square);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new BlackBishop(newSquare);
        }

        public override IPiece Clone(ISquare newSquare, IMovement lastMove)
        {
            return new BlackBishop(newSquare, lastMove);
        }

        public override bool Equals(IPiece? other)
        {
            if (other is not BlackBishop otherPiece) return false;
            return otherPiece.GetSquare().GetLocation().Equals(Square.GetLocation());
        }
    }
}
