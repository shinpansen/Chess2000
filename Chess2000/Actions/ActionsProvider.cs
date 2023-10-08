using BoardGame.Game;
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
            var player = game.GetAvailablePlayers().Where(p => p.TryGetPiece(piece.Location, out _)).First();
            var otherPlayer = game.GetAvailablePlayers().Where(p => !p.TryGetPiece(piece.Location, out _)).First();
            var currentPieces = player.GetAvailablePieces().Concat(otherPlayer.GetAvailablePieces());

            var actions = new List<Drawables.Chess.Actions.Action>();
            var moves = piece.GetAvailableMoves(game);
            foreach (var move in moves)
            {
                var newPieces = new List<IPiece>(move.SimulateMove(game, player));
                foreach(var p in newPieces)
                {
                    if (!player.TryGetPiece(p.Location, out _))
                        actions.Add(otherPlayer.TryGetPiece(p.Location, out _) ? 
                            new EatAction(_graphicsDevice, _content, p.Location.ToString(), piece, move) : 
                            new MoveAction(_graphicsDevice, _content, p.Location.ToString(), piece, move));
                }
            }

            return actions;
        }
    }
}
