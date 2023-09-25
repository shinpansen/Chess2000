using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Players.Chess
{
    public class ChessPlayerBlackPieces : ChessPlayer<BlackPiece>
    {
        public ChessPlayerBlackPieces(ChessBoard board) : base(board)
        {
            
        }
    }
}
