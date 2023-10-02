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
    public sealed class BlackTower : BlackPiece
    {
        public BlackTower(ISquare square) : base(square)
        {
        }

        public BlackTower(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public BlackTower(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IGame game, IBoard board)
        {
            var provider = new QueenTowerBishopMovementsProvider(game, board, this);
            return provider.GetAvailableMoves(ChessMovementsProvider.StraightLinks);
        }

        public override IPiece Clone()
        {
            return new BlackTower(Square);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new BlackTower(newSquare);
        }

        public override IPiece Clone(ISquare newSquare, IMovement lastMove)
        {
            return new BlackTower(newSquare, lastMove);
        }

        public override bool Equals(IPiece? other)
        {
            if (other is not BlackTower otherPiece) return false;
            return otherPiece.GetSquare().GetLocation().Equals(Square.GetLocation());
        }
    }
}
