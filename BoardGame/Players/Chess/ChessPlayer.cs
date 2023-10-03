using BoardGame.Board.Chess;
using BoardGame.Game;
using BoardGame.Pieces;
using BoardGame.Pieces.Chess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Players.Chess;

public class ChessPlayer : Player
{
    public ChessPlayer(List<IPiece> pieces) : base(pieces)
    {
    }
}
