using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Rules.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Visitors
{
    public class MovementsRulesVisitor
    {
        private readonly IMovementsRules _visitedRules;

        public MovementsRulesVisitor(IMovementsRules visitedRules)
        {
            _visitedRules = visitedRules;
        }

        public List<IMovement> GetAvailableMoves(BlackPawn pawn)
        {
            return _visitedRules.GetAvailableMoves(pawn);
        }
    }
}
