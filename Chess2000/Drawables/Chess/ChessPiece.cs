using BoardGame.Pieces;
using Chess2000.Window;
using Chess2000.Window.Chess;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Chess2000.Drawables.Chess
{
    internal class ChessPiece : SelfDrawable, IDrawable, IClickable
    {
        public enum PieceColor
        {
            Black = 0,
            White = 1
        }

        public int DrawOrder => 2;
        public bool Visible => true;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        private IPiece _piece { get; set; }
        private PieceColor _pieceColor { get; set; }
        private Texture2D _texture2D {  get; set; }
        private Rectangle _rectangle { get; set; }
        private Dictionary<string, string> _texturesValues = new Dictionary<string, string>()
        {
            { "B", "Bishop" },
            { "K", "King" },
            { "C", "Knight" },
            { "P", "Pawn" },
            { "Q", "Queen" },
            { "T", "Tower" }
        };

        public ChessPiece(GraphicsDevice graphicsDevice, ContentManager content, IPiece piece, PieceColor color) : 
            base(graphicsDevice, content)
        {
            _piece = piece;
            _pieceColor = color;
            _texture2D = _texturesValues.ContainsKey(piece.ToString()) ?
                Content.Load<Texture2D>("ChessPieces/" + _pieceColor.ToString() + " " + _texturesValues[piece.ToString()]) :
                Content.Load<Texture2D>("ChessPieces/default");
            _rectangle = new GameBoardLocation(GraphicsDevice, _piece.Location.ToString(), ChessBoard.SquareSize).Rectangle;
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
