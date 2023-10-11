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
using static System.Collections.Specialized.BitVector32;

namespace Chess2000.Actions
{
    internal class ActionsProvider
    {
        private GraphicsDevice _graphicsDevice { get; set; }
        private ContentManager _content { get; set; }

        public ActionsProvider(GraphicsDevice graphicsDevice, ContentManager content)
        {
            _graphicsDevice = graphicsDevice;
            _content = content;
        }

        public List<Drawables.Chess.Actions.Action> GetAvailableActions(IGame game, IPiece piece)
        {
            /*var player = game.GetAvailablePlayers().Where(p => p.TryGetPiece(piece.Location, out _)).First();
            var otherPlayer = game.GetAvailablePlayers().Where(p => !p.TryGetPiece(piece.Location, out _)).First();
            var currentPieces = player.GetAvailablePieces().Concat(otherPlayer.GetAvailablePieces());*/

            var actions = new List<Drawables.Chess.Actions.Action>();
            piece.GetAvailableMoves(game).ForEach(move => actions.Add(GetAction(piece, move)));
            /*foreach (var move in moves)
            {
                var action = GetAction(piece, move);
                if(action is not null)
                actions.Add(action);
                var newPieces = new List<IPiece>(move.SimulateMove(game, player));
                foreach(var p in newPieces)
                {
                    if (!player.TryGetPiece(p.Location, out _))
                        actions.Add(otherPlayer.TryGetPiece(p.Location, out _) ? 
                            new EatAction(_graphicsDevice, _content, p.Location.ToString(), piece, move) : 
                            new MoveAction(_graphicsDevice, _content, p.Location.ToString(), piece, move));
                }
            }*/

            return actions;
        }

        private Drawables.Chess.Actions.Action GetAction(IPiece piece, IMovement move)
        {
            if (move is ChessMovementEat || move is ChessMovementEnPassant)
                return new EatAction(_graphicsDevice, _content, move.TargetLocation.ToString(), piece, move);
            else if (move is ChessMovementRock)
                return new RockAction(_graphicsDevice, _content, move.TargetLocation.ToString(), piece, move);
            else if (move is ChessMovementBase || move is ChessMovementPawnDouble)
                return new MoveAction(_graphicsDevice, _content, move.TargetLocation.ToString(), piece, move);

            return new MoveAction(_graphicsDevice, _content, move.TargetLocation.ToString(), piece, move);
        }
    }
}
