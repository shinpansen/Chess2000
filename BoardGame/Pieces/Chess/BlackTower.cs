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
    public sealed class BlackTower : BlackPiece
    {
        private BlackTower(ISquare square) : base(square)
        {
        }

        private BlackTower(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public BlackTower(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
        {
            var provider = new QueenTowerBishopMovementsProvider(rules, this);
            return provider.GetAvailableMoves(ChessMovementsProvider.StraightLinks);
        }

        public override IPiece Clone()
        {
            return new BlackTower(Square);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new BlackTower(newSquare);
        }

        public override IPiece Clone(ISquare newSquare, IMovement lastMove)
        {
            return new BlackTower(newSquare, lastMove);
        }

        public override bool Equals(IPiece? other)
        {
            if (other is not BlackTower otherPiece) return false;
            return otherPiece.GetSquare().GetLocation().Equals(Square.GetLocation());
        }
    }
}
