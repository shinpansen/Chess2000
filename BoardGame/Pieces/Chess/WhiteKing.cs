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
    public sealed class WhiteKing : WhitePiece
    {
        private WhiteKing(ISquare square) : base(square)
        {
        }

        private WhiteKing(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public WhiteKing(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
        {
            var provider = new KingMovementsProvider(rules, this);
            return provider.GetAvailableMoves();
        }

        public override IPiece Clone()
        {
            return new WhiteKing(Square);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new WhiteKing(newSquare);
        }

        public override IPiece Clone(ISquare newSquare, IMovement lastMove)
        {
            return new WhiteKing(newSquare, lastMove);
        }

        public override bool Equals(IPiece? other)
        {
            if (other is not WhiteKing otherPiece) return false;
            return otherPiece.GetSquare().GetLocation().Equals(Square.GetLocation());
        }
    }
}
