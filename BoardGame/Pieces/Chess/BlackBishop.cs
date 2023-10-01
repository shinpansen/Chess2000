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
        private BlackBishop(ISquare square) : base(square)
        {
        }

        private BlackBishop(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public BlackBishop(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
        {
            if (rules is ChessMovementsRules chessMovementsRules)
                return chessMovementsRules.GetAvailableMoves(this);
            throw new ArgumentException(nameof(BlackBishop) + " can't follow those rules");
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
    }
}
