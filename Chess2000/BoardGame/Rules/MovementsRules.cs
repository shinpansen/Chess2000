using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Rules
{
    public abstract class MovementsRules : IMovementsRules
    {
        protected IGame Game { get; set; }
        protected IBoard Board { get; set; }
        protected IPiece Piece { get; set; }
        protected List<IMovement> availableMoves { get; set; }

        public MovementsRules(IGame game, IBoard board, IPiece piece)
        {
            Game = game;
            Board = board;
            Piece = piece;
            availableMoves = Piece.GetAvailableMoves(this);
        }
        
        public virtual ReadOnlyCollection<IMovement> GetAvailableMoves()
        {
            return availableMoves.AsReadOnly();
        }
    }
}
