using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Location.Links;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Rules
{
    public abstract class MovementsProvider : IMovementProvider
    {
        protected IBoard Board { get; set; }
        protected IGame Game { get; set; }
        protected IPiece Piece { get; set; }

        protected MovementsProvider(IGame game, IBoard board, IPiece piece)
        {
            Game = game;
            Board = board;
            Piece = piece;
        }

        public virtual bool TryGetSquare(Queue<ISquareLink> links, out ISquare square)
        {
            square = default;

            var location = Piece.GetSquare().GetLocation();
            while (links.Any() && location.GetNeighbors().Any(l => l.Key.Equals(links.First())))
            {
                location = location.GetNeighbors().First(l => l.Key.Equals(links.First())).Value;
                links.Dequeue();
            }
            if (links.Any()) return false;

            square = Board.GetSquare(location);
            return true;
        }
    }
}
