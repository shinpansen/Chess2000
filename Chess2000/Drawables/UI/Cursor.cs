using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chess2000.Drawables.Chess.ChessPiece;
using Microsoft.Xna.Framework.Input;
using Chess2000.Window;

namespace Chess2000.Drawables.UI
{
    public class Cursor : Drawable
    {
        public override int DrawOrder => 3;
        public override event EventHandler<EventArgs> DrawOrderChanged;
        public override event EventHandler<EventArgs> VisibleChanged;

        public bool MouseOverClickable
        {
            get
            {
                var mousePos = new Point(Mouse.GetState().X, Mouse.GetState().Y);
                foreach (var clickable in _myGame.GameClickables)
                    if (clickable.Contains(mousePos))
                        return true;
                return false;
            }
        }

        private MyGame _myGame;
        private Texture2D _defaultTexture;
        private Texture2D _actionTexture;

        public Cursor(GraphicsManager graphicsManager, MyGame myGame) : base(graphicsManager)
        {
            _myGame = myGame;
            _defaultTexture = Content.Load<Texture2D>("UI/Cursor/Default");
            _actionTexture = Content.Load<Texture2D>("UI/Cursor/Action");
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            var mouseOver = MouseOverClickable;
            var mousePos = new Point(Mouse.GetState().X, Mouse.GetState().Y);
            var rect = new Rectangle(mousePos.X - (mouseOver ? 25 : 17), mousePos.Y - 10, 64, 64);
            SpriteBatch.Draw(mouseOver ? _actionTexture : _defaultTexture, rect, MyGame.TransparencyColor);
            SpriteBatch.End();
        }
    }
}
