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
    public sealed class WhiteTower : WhitePiece
    {
        private WhiteTower(ISquare square) : base(square)
        {
        }

        private WhiteTower(ISquare square, IMovement lastMove) : base(square, lastMove)
        {
        }

        public WhiteTower(string location) : base(location)
        {
        }

        public override List<IMovement> GetAvailableMoves(IMovementsRules rules)
        {
            var provider = new QueenTowerBishopMovementsProvider(rules, this);
            return provider.GetAvailableMoves(ChessMovementsProvider.StraightLinks);
        }

        public override IPiece Clone()
        {
            return new WhiteTower(Square);
        }

        public override IPiece Clone(ISquare newSquare)
        {
            return new WhiteTower(newSquare);
        }

        public override IPiece Clone(ISquare newSquare, IMovement lastMove)
        {
            return new WhiteTower(newSquare, lastMove);
        }

        public override bool Equals(IPiece? other)
        {
            if (other is not WhiteTower otherPiece) return false;
            return otherPiece.GetSquare().GetLocation().Equals(Square.GetLocation());
        }
    }
}
