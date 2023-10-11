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
using BoardGame.Movements.Chess;
using BoardGame.Pieces.Visitors;

namespace BoardGame.Players.Chess;

public class ChessPlayer : Player
{
    public ChessPlayer(List<IPiece> pieces) : base(pieces)
    {
        BeforeTurnStarts += (sender, args) =>
        {
            var newPieces = new List<IPiece>();
            foreach (var piece in AvailablePieces)
            {
                var lastMove = piece.Visit(new MovementPieceVisitor());
                newPieces.Add(lastMove is IChessMovementPawnDouble move ?
                    piece.Clone(piece.GetSquare(), move.OnBeforeTurnStarts()) : 
                    piece.Clone());
            }

            AvailablePieces = newPieces;
        };
    }
}
