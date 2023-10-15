using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chess2000.Drawables.Chess.ChessPiece;
using Chess2000.Drawables.Chess;

namespace Chess2000.Drawables.UI
{
    public class CheckSourceHighlight : ChessDrawable
    {
        public override int DrawOrder => 1;
        public override event EventHandler<EventArgs> DrawOrderChanged;
        public override event EventHandler<EventArgs> VisibleChanged;

        private string _location { get; set; }
        private Texture2D _texture2D { get; set; }

        public CheckSourceHighlight(GraphicsManager graphicsManager, string location) : base(graphicsManager)
        {
            _location = location;
            _texture2D = Content.Load<Texture2D>("UI/Actions/CheckSource");
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            var rect = ChessBoardPositionFinder.GetRectangle(_location, ChessBoard.SquareSize);
            SpriteBatch.Draw(_texture2D, rect, MyGame.TransparencyColor);
            SpriteBatch.End();
        }
    }
}
