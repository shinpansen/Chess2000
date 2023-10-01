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
    public class QueenTowerBishopMovementsProvider : ChessMovementsProvider
    {
        public QueenTowerBishopMovementsProvider(IGame game, IBoard board, IPiece piece) : base(game, board, piece)
        {
        }

        public List<IMovement> GetAvailableMoves(params List<ISquareLink>[] authorizedDirections)
        {
            var moves = new List<IMovement>();

            //Diagonal direction, max 8 squares
            foreach (var dir in authorizedDirections)
            {
                foreach (var link in dir)
                {
                    for (ushort i = 1; i <= 8; i++)
                    {
                        var links = new Link2DGridBuilder().Link(link, i).Build();
                        if (TryGetSquareEmptyOrWithOpponent(links, out var square, true))
                            moves.Add(new ChessMovementBase(Piece, square));
                    }
                }
            }

            return moves;
        }
    }
}
