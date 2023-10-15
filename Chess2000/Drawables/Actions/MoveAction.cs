using BoardGame.Movements;
using BoardGame.Pieces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.Drawables.Actions
{
    public class MoveAction : Action
    {
        public MoveAction(GraphicsManager graphicsManager, string location, IPiece piece, IMovement move) :
            base(graphicsManager, location, piece, move)
        {
            Texture2D = Content.Load<Texture2D>("UI/Actions/Move");
        }
    }
}
