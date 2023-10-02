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
    public sealed class WhiteKing : WhitePiece
    {
        public WhiteKing(ISquare square) : base(square)
        {
        }

        public WhiteKing(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public WhiteKing(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IGame game, IBoard board)
        {
            var provider = new KingMovementsProvider(game, board, this);
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
