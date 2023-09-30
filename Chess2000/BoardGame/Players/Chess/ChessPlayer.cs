using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Players.Chess
{
    public class ChessPlayer<TP> : IPlayer where TP : ChessPiece
    {
        public List<TP> PlayerPieces { get; private set; }

        public ChessPlayer(ChessBoard board)
        {
            PlayerPieces = new List<TP>();
        }
    }
}
