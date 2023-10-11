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

namespace BoardGame.MovementsProviders.Chess
{
    public class QueenTowerBishopMovementsProvider : ChessMovementsProvider
    {
        public QueenTowerBishopMovementsProvider(IGame game, IBoard board, IPiece piece, 
            params List<ISquareLink>[] authorizedDirections) : base(game, board, piece)
        {
            //Diagonal direction, max 8 squares
            foreach (var dir in authorizedDirections)
            {
                foreach (var link in dir)
                {
                    for (int i = 1; i <= 8; i++)
                    {
                        var links = new Link2DGridBuilder().Link(link, i).Build();
                        if (TryGetSquareEmptyOrWithOpponent(links, out var square, true))
                            Moves.Add(TryGetPiece(square.GetLocation(), out _) ? 
                                new ChessMovementEat(Piece, square) : 
                                new ChessMovementBase(Piece, square));
                    }
                }
            }
        }
    }
}
