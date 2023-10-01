﻿using BoardGame.Movements;
using BoardGame.MovementsRules.Chess;
using BoardGame.MovementsRules;
using BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Pieces.Chess
{
    public sealed class WhiteKnight : WhitePiece
    {
        private WhiteKnight(ISquare square) : base(square)
        {
        }

        private WhiteKnight(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public WhiteKnight(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
        {
            if (rules is ChessMovementsRules chessMovementsRules)
                return chessMovementsRules.GetAvailableMoves(this);
            throw new ArgumentException(nameof(WhiteKnight) + " can't follow those rules");
        }

        public override IPiece Clone()
        {
            return new WhiteKnight(Square);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new WhiteKnight(newSquare);
        }

        public override IPiece Clone(ISquare newSquare, IMovement lastMove)
        {
            return new WhiteKnight(newSquare, lastMove);
        }
    }
}
