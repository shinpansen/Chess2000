using BoardGame.Movements;
using BoardGame.MovementsProviders.Chess;
using BoardGame.MovementsProviders;
using BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGame.Board;
using BoardGame.Game;

namespace BoardGame.Pieces.Chess
{
    public sealed class BlackKnight : BlackPiece
    {
        private BlackKnight(ISquare square) : base(square)
        {
        }

        public BlackKnight(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public BlackKnight(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IGame game, IBoard board)
        {
            var provider = new KnightMovementsProvider(game, board, this);
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
