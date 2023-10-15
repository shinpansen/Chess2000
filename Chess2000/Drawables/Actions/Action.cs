using BoardGame.Movements;
using BoardGame.Pieces;
using Chess2000.Drawables.Chess;
using Chess2000.Window;
using Chess2000.Window.Chess;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.Drawables.Actions
{
    public abstract class Action : ChessDrawable, IClickable
    {
        public override int DrawOrder => 1;
        public override event EventHandler<EventArgs> DrawOrderChanged;
        public override event EventHandler<EventArgs> VisibleChanged;
        public bool IsSelected { get; set; }
        public string Location { get; private set; }
        public IPiece Piece { get; private set; }
        public IMovement Move { get; private set; }

        protected Texture2D Texture2D { get; init; }

        protected Action(GraphicsManager graphicsManager, string location, IPiece piece, IMovement move) : base(graphicsManager)
        {
            Location = location;
            Piece = piece;
            Move = move;
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            var rect = ChessBoardPositionFinder.GetRectangle(Location, ChessBoard.SquareSize);
            SpriteBatch.Draw(Texture2D, rect, MyGame.TransparencyColor);
            SpriteBatch.End();
        }

        public bool Contains(Point point)
        {
            var rect = ChessBoardPositionFinder.GetRectangle(Location, ChessBoard.SquareSize);
            return rect.Contains(point);
        }
    }
}
