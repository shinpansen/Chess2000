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
    public sealed class BlackKnight : BlackPiece
    {
        private BlackKnight(ISquare square) : base(square)
        {
        }

        private BlackKnight(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public BlackKnight(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
        {
            var provider = new KnightMovementsProvider(rules, this);
            return provider.GetAvailableMoves();
        }

        public override IPiece Clone()
        {
            return new BlackKnight(Square);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new BlackKnight(newSquare);
        }

        public override IPiece Clone(ISquare newSquare, IMovement lastMove)
        {
            return new BlackKnight(newSquare, lastMove);
        }

        public override bool Equals(IPiece? other)
        {
            if (other is not BlackKnight otherPiece) return false;
            return otherPiece.GetSquare().GetLocation().Equals(Square.GetLocation());
        }
    }
}
