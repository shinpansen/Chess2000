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
    public sealed class Knight : ChessPiece
    {
        private Knight(ISquare square) : base(square)
        {
        }

        private Knight(ISquare square, IMovement? lastMove) : base(square, lastMove)
        {
        }

        public Knight(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IGame game)
        {
            var provider = new KnightMovementsProvider(game, game.Board, this);
            return provider.GetAvailableMoves();
        }

        public override List<IMovement> SimulateAvailableMoves(IGame game, IBoard board)
        {
            var provider = new KnightMovementsProvider(game, board, this);
            return provider.SimulateAvailableMoves();
        }

        public override IPiece Clone()
        {
            return new Knight(Square);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new Knight(newSquare);
        }

        public override IPiece Clone(ISquare newSquare, IMovement? lastMove)
        {
            return new Knight(newSquare, lastMove);
        }

        public override bool Equals(IPiece? other)
        {
            if (other is not Knight otherPiece) return false;
            return otherPiece.Location.Equals(Square.GetLocation());
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
