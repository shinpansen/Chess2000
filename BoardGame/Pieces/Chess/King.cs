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
    public sealed class King : ChessPiece, IKing
    {
        private King(ISquare square) : base(square)
        {
        }

        private King(ISquare square, IMovement? lastMove) : base(square, lastMove)
        {
        }

        public King(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IGame game)
        {
            var provider = new KingMovementsProvider(game, game.Board, this);
            return provider.GetAvailableMoves();
        }

        public override List<IMovement> SimulateAvailableMoves(IGame game, IBoard board)
        {
            var provider = new KingMovementsProvider(game, board, this);
            return provider.SimulateAvailableMoves();
        }

        public override IPiece Clone()
        {
            return new King(Square, LastMove);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new King(newSquare, LastMove);
        }

        public override IPiece Clone(ISquare newSquare, IMovement? lastMove)
        {
            return new King(newSquare, lastMove);
        }

        public override bool Equals(IPiece? other)
        {
            if (other is not King otherPiece) return false;
            return otherPiece.Location.Equals(Square.GetLocation());
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
