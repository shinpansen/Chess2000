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
    public sealed class Bishop : ChessPiece
    {
        private Bishop(ISquare square) : base(square)
        {
        }

        private Bishop(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public Bishop(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IGame game, IBoard board)
        {
            var provider = new QueenTowerBishopMovementsProvider(game, board, this);
            return provider.GetAvailableMoves(ChessMovementsProvider.DiagonalLinks);
        }

        public override IPiece Clone()
        {
            return new Bishop(Square);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new Bishop(newSquare);
        }

        public override IPiece Clone(ISquare newSquare, IMovement lastMove)
        {
            return new Bishop(newSquare, lastMove);
        }

        public override bool Equals(IPiece? other)
        {
            if (other is not Bishop otherPiece) return false;
            return otherPiece.Location.Equals(Square.GetLocation());
        }
    }
}
