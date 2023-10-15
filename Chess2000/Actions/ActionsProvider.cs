using BoardGame.Game;
using BoardGame.Movements;
using BoardGame.Movements.Chess;
using BoardGame.Pieces;
using BoardGame.Players;
using Chess2000.Drawables.Chess.Actions;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess2000.Drawables;
using static System.Collections.Specialized.BitVector32;

namespace Chess2000.Actions
{
    internal class ActionsProvider
    {
        private readonly DrawTools _dt;

        public ActionsProvider(DrawTools drawTools)
        {
            _dt = drawTools;
        }

        public List<Drawables.Chess.Actions.Action> GetAvailableActions(IGame game, IPiece piece)
        {
            var actions = new List<Drawables.Chess.Actions.Action>();
            piece.GetAvailableMoves(game).ForEach(move => actions.Add(GetAction(piece, move)));

            return actions;
        }

        private Drawables.Chess.Actions.Action GetAction(IPiece piece, IMovement move)
        {
            switch (move)
            {
                case ChessMovementEat:
                case ChessMovementEnPassant:
                    return new EatAction(_dt, move.TargetLocation!.ToString(), piece, move);
                case ChessMovementRock:
                    return new RockAction(_dt, move.TargetLocation!.ToString(), piece, move);
                case ChessMovementPawnDouble:
                case ChessMovementBase:
                    return new MoveAction(_dt, move.TargetLocation!.ToString(), piece, move);
                default:
                    return new MoveAction(_dt, move.TargetLocation!.ToString(), piece, move);
            }
        }
    }
}
