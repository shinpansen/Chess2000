using BoardGame.Board;
using BoardGame.Game;
using BoardGame.Movements.Chess;
using BoardGame.Movements;
using BoardGame.Pieces;
using BoardGame.SquaresLocation.Links._2DGrid;
using BoardGame.SquaresLocation.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.MovementsRules.Chess
{
    public class BishopMovementsProvider : ChessMovementsProvider
    {
        public BishopMovementsProvider(IGame game, IBoard board, IPiece piece) : base(game, board, piece)
        {
        }

        public List<IMovement> GetAvailableMoves()
        {
            var moves = new List<IMovement>();

            //All directions, one square move
            foreach (var link in DiagonalLinks) AddAvailableMove(moves, link);
            return moves;
        }

        private void AddAvailableMove(List<IMovement> moves, ISquareLink link)
        {
            var links = new Link2DGridBuilder().Link(link).Build();
            if (TryGetSquareEmptyOrWithOpponent(links, out var s))
                moves.Add(new ChessMovementBase(Piece, s));
        }
    }
}
