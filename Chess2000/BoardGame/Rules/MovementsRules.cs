using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Movement;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Rules
{
    public abstract class MovementsRules<TPiece> : IMovementsRules where TPiece : IPiece
    {
        protected IGame<TPiece> Game { get; set; }
        protected IBoard Board { get; set; }
        protected TPiece Piece { get; set; }

        public MovementsRules(IGame<TPiece> game, IBoard board, TPiece piece)
        {
            Game = game;
            Board = board;
            Piece = piece;
        }

        public virtual List<IMovement> GetAvailableMoves()
        {
            return Piece.GetAvailableMoves(this);
        }
    }
}
