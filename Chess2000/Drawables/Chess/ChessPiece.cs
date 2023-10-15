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
    internal class ChessPiece : ChessDrawable, IClickable
    {
        public enum PieceColor
        {
            Black = 0,
            White = 1
        }

        public override int DrawOrder => 2;
        public override bool Visible => true;
        public override event EventHandler<EventArgs> DrawOrderChanged;
        public override event EventHandler<EventArgs> VisibleChanged;
        public bool IsSelected { get; set; }
        public IPiece Piece { get; private set; }

        private PieceColor _pieceColor { get; set; }
        private Texture2D _texture2D {  get; set; }
        private readonly Dictionary<string, string> _texturesValues = new Dictionary<string, string>()
        {
            { "B", "Bishop" },
            { "K", "King" },
            { "C", "Knight" },
            { "P", "Pawn" },
            { "Q", "Queen" },
            { "T", "Tower" }
        };

        public ChessPiece(DrawTools drawTools, IPiece piece, PieceColor color = PieceColor.Black) : base(drawTools)
        {
            Piece = piece;
            _pieceColor = color;
            _texture2D = _texturesValues.ContainsKey(piece.ToString()) ?
                Content.Load<Texture2D>("ChessPieces/" + _pieceColor.ToString() + " " + _texturesValues[piece.ToString()]) :
                Content.Load<Texture2D>("ChessPieces/default");
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            var rect = ChessBoardPositionFinder.GetRectangle(Piece.Location.ToString(), ChessBoard.SquareSize);
            SpriteBatch.Draw(_texture2D, rect, MyGame.TransparencyColor);
            SpriteBatch.End();
        }

        public bool IsClicked(Point point)
        {
            var rect = ChessBoardPositionFinder.GetRectangle(Piece.Location.ToString(), ChessBoard.SquareSize);
            return rect.Contains(point);
        }
    }
}
