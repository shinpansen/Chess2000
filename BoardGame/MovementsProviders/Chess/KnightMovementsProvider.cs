using BoardGame.Board;
using BoardGame.Game;
using BoardGame.Movements;
using BoardGame.Movements.Chess;
using BoardGame.Pieces;
using BoardGame.Pieces.Chess;
using BoardGame.SquaresLocation.Links;
using BoardGame.SquaresLocation.Links._2DGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.MovementsProviders.Chess
{
    public class KnightMovementsProvider : ChessMovementsProvider
    {
        public KnightMovementsProvider(IGame game, IBoard board, IPiece piece) : base(game, board, piece)
        {
            //All "L" moves
            List<Queue<ISquareLink>> possibleLinks = new List<Queue<ISquareLink>>()
            {
                new Link2DGridBuilder().Top().Top().Left().Build(),
                new Link2DGridBuilder().Top().Top().Right().Build(),
                new Link2DGridBuilder().Bottom().Bottom().Left().Build(),
                new Link2DGridBuilder().Bottom().Bottom().Right().Build(),
                new Link2DGridBuilder().Top().Left().Left().Build(),
                new Link2DGridBuilder().Top().Right().Right().Build(),
                new Link2DGridBuilder().Bottom().Left().Left().Build(),
                new Link2DGridBuilder().Bottom().Right().Right().Build()
            };
            foreach (var links in possibleLinks)
                if (TryGetSquareEmptyOrWithOpponent(links, out var square))
                    Moves.Add(new ChessMovementBase(Piece, square));
        }
    }
}
