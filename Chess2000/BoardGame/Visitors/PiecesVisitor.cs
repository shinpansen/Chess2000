using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Visitors
{
    public class PiecesVisitor
    {
        private readonly IPiece _visitedPiece;

        public PiecesVisitor(IPiece visitedPiece)
        {
            _visitedPiece = visitedPiece;
        }

        public bool Visit(BlackPiece p1) => _visitedPiece is BlackPiece;

        public bool Visit(WhitePiece p1) => _visitedPiece is WhitePiece;
    }
}
