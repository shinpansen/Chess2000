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
    public sealed class WhiteKnight : WhitePiece
    {
        public WhiteKnight(ISquare square) : base(square)
        {
        }

        public WhiteKnight(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public WhiteKnight(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IGame game, IBoard board)
        {
            var provider = new KnightMovementsProvider(game, board, this);
            return provider.GetAvailableMoves();
        }

        public override IPiece Clone()
        {
            return new WhiteKnight(Square);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new WhiteKnight(newSquare);
        }

        public override IPiece Clone(ISquare newSquare, IMovement lastMove)
        {
            return new WhiteKnight(newSquare, lastMove);
        }

        public override bool Equals(IPiece? other)
        {
            if (other is not WhiteKnight otherPiece) return false;
            return otherPiece.GetSquare().GetLocation().Equals(Square.GetLocation());
        }
    }
}
