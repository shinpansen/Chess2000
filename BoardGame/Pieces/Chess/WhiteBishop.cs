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
    public sealed class WhiteBishop : WhitePiece
    {
        private WhiteBishop(ISquare square) : base(square)
        {
        }

        private WhiteBishop(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public WhiteBishop(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
        {
            if (rules is ChessMovementsRules chessMovementsRules)
                return chessMovementsRules.GetAvailableMoves(this);
            throw new ArgumentException(nameof(WhiteBishop) + " can't follow those rules");
        }

        public override IPiece Clone()
        {
            return new WhiteBishop(Square);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new WhiteBishop(newSquare);
        }

        public override IPiece Clone(ISquare newSquare, IMovement lastMove)
        {
            return new WhiteBishop(newSquare, lastMove);
        }
    }
}
