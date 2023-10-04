using BoardGame.Pieces;
using BoardGame.SquaresLocation.Chess;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using System.Data.Common;

namespace Chess2000.Graphics
{
    internal class MonoGameChessBoard : MonoGame2DGraphicalObject
    {
        private int _squareSize { get; set; }
        private Texture2D _graySquare { get; set; }
        private Texture2D _purpleSquare { get; set; }

        public MonoGameChessBoard(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, int squareSize) : base(graphicsDevice, spriteBatch)
        {
            _squareSize = squareSize;
            _graySquare = new Texture2D(graphicsDevice, 1, 1);
            _graySquare.SetData(new[] { Color.Gray });
            _purpleSquare = new Texture2D(graphicsDevice, 1, 1);
            _purpleSquare.SetData(new[] { Color.MediumPurple });
        }

        public override void Draw(Point centerPoint, ContentManager content)
        {
            int boardSize = _squareSize * 8;
            var font = content.Load<SpriteFont>("Fonts/BoardFont");

            SpriteBatch.Begin();
            for (int row = 0; row < 8; row++)
            {
                SpriteBatch.DrawString(font, (8 - row).ToString(),
                    new Vector2(centerPoint.X - boardSize / 2 - _squareSize,
                        centerPoint.Y + _squareSize * row - boardSize / 2 + 4),
                        Color.MediumPurple);
                for (int column = 0; column < 8; column++)
                {
                    SpriteBatch.Draw((row + column) % 2 == 0 ? _graySquare : _purpleSquare,
                        GetRetangleSquare(centerPoint, row, column), 
                        Color.White);

                    if (row > 0) continue;
                    SpriteBatch.DrawString(font, ChessSquareLocation.AvailableColumns[column],
                        new Vector2(centerPoint.X - boardSize / 2 + column * _squareSize + 20,
                            centerPoint.Y + boardSize / 2 + 8),
                            Color.DarkGray);
                }
            }
            SpriteBatch.End();
        }

        public void DrawChessPiece(Point centerPoint, IPiece piece, string color, ContentManager content)
        {
            string location = piece.Location.ToString();
            if (!Regex.IsMatch(location, "[A-H][1-8]"))
                throw new Exception("Invalid location");

            int row = 8 - (Array.IndexOf(ChessSquareLocation.AvailableColumns, location.Substring(0, 1)) + 1);
            int column = int.Parse(location.Substring(1)) - 1;

            SpriteBatch.Begin();
            SpriteBatch.Draw(new PiecesTexturesLoader(piece, color, content).Texture, 
                GetRetangleSquare(centerPoint, row, column), Color.Pink);
            SpriteBatch.End();
        }

        private Rectangle GetRetangleSquare(Point centerPoint, int row, int column)
        {
            int boardSize = _squareSize * 8;
            return new Rectangle(centerPoint.X + (row * _squareSize) - (boardSize / 2),
                            centerPoint.Y + (column * _squareSize) - (boardSize / 2),
                            _squareSize,
                            _squareSize);
        }
    }
}
