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
    public sealed class Queen : ChessPiece
    {
        private Queen(ISquare square) : base(square)
        {
        }

        private Queen(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public Queen(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IGame game, IBoard board)
        {
            var provider = new QueenTowerBishopMovementsProvider(game, board, this);
            return provider.GetAvailableMoves(ChessMovementsProvider.StraightLinks, ChessMovementsProvider.DiagonalLinks);
        }

        public override IPiece Clone()
        {
            return new Queen(Square);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new Queen(newSquare);
        }

        public override IPiece Clone(ISquare newSquare, IMovement lastMove)
        {
            return new Queen(newSquare, lastMove);
        }

        public override bool Equals(IPiece? other)
        {
            if (other is not Queen otherPiece) return false;
            return otherPiece.Location.Equals(Square.GetLocation());
        }
    }
}
