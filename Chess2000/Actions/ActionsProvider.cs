using BoardGame.Game;
using BoardGame.Movements;
using BoardGame.Movements.Chess;
using BoardGame.Pieces;
using BoardGame.Players;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess2000.Drawables;
using Chess2000.Drawables.Actions;

namespace Chess2000.Actions
{
    public class ActionsProvider
    {
        private readonly GraphicsManager _graphicsManager;

        public ActionsProvider(GraphicsManager graphicsManager)
        {
            _graphicsManager = graphicsManager;
        }

        public List<Drawables.Actions.Action> GetAvailableActions(IGame game, IPiece piece)
        {
            var actions = new List<Drawables.Actions.Action>();
            piece.GetAvailableMoves(game).ForEach(move => actions.Add(GetAction(piece, move)));

            return actions;
        }

        private Drawables.Actions.Action GetAction(IPiece piece, IMovement move)
        {
            switch (move)
            {
                case ChessMovementEat:
                case ChessMovementEnPassant:
                    return new EatAction(_graphicsManager, move.TargetLocation!.ToString(), piece, move);
                case ChessMovementRock:
                    return new RockAction(_graphicsManager, move.TargetLocation!.ToString(), piece, move);
                case ChessMovementPawnDouble:
                case ChessMovementBase:
                    return new MoveAction(_graphicsManager, move.TargetLocation!.ToString(), piece, move);
                default:
                    return new MoveAction(_graphicsManager, move.TargetLocation!.ToString(), piece, move);
            }
        }
    }
}
