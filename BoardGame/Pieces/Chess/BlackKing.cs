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
    public sealed class BlackKing : BlackPiece
    {
        private BlackKing(ISquare square) : base(square)
        {
        }

        private BlackKing(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public BlackKing(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
        {
            var provider = new KingMovementsProvider(rules, this);
            return provider.GetAvailableMoves();
        }

        public override IPiece Clone()
        {
            return new BlackKing(Square);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new BlackKing(newSquare);
        }

        public override IPiece Clone(ISquare newSquare, IMovement lastMove)
        {
            return new BlackKing(newSquare, lastMove);
        }

        public override bool Equals(IPiece? other)
        {
            if (other is not BlackKing otherPiece) return false;
            return otherPiece.GetSquare().GetLocation().Equals(Square.GetLocation());
        }
    }
}
