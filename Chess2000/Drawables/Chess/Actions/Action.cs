using BoardGame.Movements;
using BoardGame.Pieces;
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

namespace Chess2000.Drawables.Chess.Actions
{
    internal abstract class Action : SelfDrawable, IDrawable, IClickable
    {
        public int DrawOrder => 1;
        public bool Visible => true;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public string Location { get; private set; }
        public IPiece Piece { get; private set; }
        public IMovement Move { get; private set; }

        protected Texture2D _texture2D { get; set; }

        private Rectangle _rectangle { get; set; }

        public Action(GraphicsDevice graphicsDevice, ContentManager content, string location, IPiece piece, IMovement move) : 
            base(graphicsDevice, content)
        {
            Location = location;
            Piece = piece;
            Move = move;
            _rectangle = new GameBoardLocation(GraphicsDevice, Location, ChessBoard.SquareSize).Rectangle;
        }

        public void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(_texture2D, _rectangle, MyGame.TransparencyColor);
            SpriteBatch.End();
        }

        public bool IsClicked(Point point)
        {
            return _rectangle.Contains(point);
        }
    }
}
