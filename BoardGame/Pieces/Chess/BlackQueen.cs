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
    public sealed class BlackQueen : BlackPiece
    {
        private BlackQueen(ISquare square) : base(square)
        {
        }

        private BlackQueen(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public BlackQueen(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
        {
            var provider = new QueenTowerBishopMovementsProvider(rules, this);
            return provider.GetAvailableMoves(ChessMovementsProvider.StraightLinks, ChessMovementsProvider.DiagonalLinks);
        }

        public override IPiece Clone()
        {
            return new BlackQueen(Square);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new BlackQueen(newSquare);
        }

        public override IPiece Clone(ISquare newSquare, IMovement lastMove)
        {
            return new BlackQueen(newSquare, lastMove);
        }

        public override bool Equals(IPiece? other)
        {
            if (other is not BlackQueen otherPiece) return false;
            return otherPiece.GetSquare().GetLocation().Equals(Square.GetLocation());
        }
    }
}
