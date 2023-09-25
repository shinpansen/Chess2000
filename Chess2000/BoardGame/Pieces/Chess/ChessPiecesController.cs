using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Pieces.Chess
{
    public class ChessPiecesController : 
        IPiecesController<ChessBoard, ChessPiece, ChessSquare, ChessSquareLocation, ChessMovement, ChessMovementRules, string>
    {
        public List<ChessPiece> Pieces { get; private set; }
        private ChessBoard _board { get; set; }

        public ChessPiecesController(ChessBoard board)
        {
            _board = board;
            Pieces = new List<ChessPiece>();

            //Pawns
            foreach (string col in ChessSquareLocation.AvailableColumns)
            {
                Pieces.Add(new BlackPawn(board.GetSquare(new ChessSquareLocation(col, 7))));
                Pieces.Add(new WhitePawn(board.GetSquare(new ChessSquareLocation(col, 2))));
            }
        }

        public void ApplyMove(ChessPiece piece, string moveKey)
        {
            var movementRules = new ChessMovementRules(piece, this, _board);
            var availableMoves =  movementRules.GetAvailableMoves();
            if (!availableMoves.Any(m => m.Key.Equals(moveKey))) throw new ArgumentException("The move doesn't exist");

            var move = availableMoves.First(m =>  m.Key.Equals(moveKey));
        }
    }
}
