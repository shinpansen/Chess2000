using BoardGame.Pieces;
using BoardGame.SquaresLocation.Chess;
using Chess2000.Window.Chess;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.Drawables.Chess
{
    public class ChessBoard : ChessDrawable
    {
        public const int SquareSize = 64;
        public override int DrawOrder => 0;
        public override event EventHandler<EventArgs> DrawOrderChanged;
        public override event EventHandler<EventArgs> VisibleChanged;

        private Texture2D _graySquare { get; set; }
        private Texture2D _purpleSquare { get; set; }
        private Dictionary<string, Texture2D> _lettersTextures { get; set; }
        private Dictionary<int, Texture2D> _numbersTextures { get; set; }

        public ChessBoard(GraphicsManager graphicsManager) : base(graphicsManager)
        {
            _graySquare = new Texture2D(GraphicsDevice, 1, 1);
            _graySquare.SetData(new[] { Color.Gray });
            _purpleSquare = new Texture2D(GraphicsDevice, 1, 1);
            _purpleSquare.SetData(new[] { Color.MediumPurple });

            _lettersTextures = new Dictionary<string, Texture2D>();
            foreach (var letter in ChessSquareLocation.AvailableColumns)
                _lettersTextures.Add(letter, Content.Load<Texture2D>("UI/Letters/" + letter));

            _numbersTextures = new Dictionary<int, Texture2D>();
            foreach (int number in Enumerable.Range(1, 8))
                _numbersTextures.Add(number, Content.Load<Texture2D>("UI/Numbers/" + number));
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            foreach (string column in ChessSquareLocation.AvailableColumns)
            {
                DrawColumnLetter(column);
                int columnInt = Array.IndexOf(ChessSquareLocation.AvailableColumns, column);
                for (int row = 1; row <= 8; row++)
                {
                    SpriteBatch.Draw((row + columnInt) % 2 == 0 ? _graySquare : _purpleSquare,
                        ChessBoardPositionFinder.GetRectangle(column + row, SquareSize), MyGame.TransparencyColor);
                    if (column == ChessSquareLocation.AvailableColumns.First()) DrawRowNumber(row);
                }
            }
            SpriteBatch.End();
        }

        private void DrawColumnLetter(string column)
        {
            var rect = ChessBoardPositionFinder.GetRectangle(column + "1", SquareSize);
            SpriteBatch.Draw(_lettersTextures[column],
                new Rectangle(rect.X, rect.Y + SquareSize, SquareSize, SquareSize), MyGame.TransparencyColor);
        }
        private void DrawRowNumber(int row)
        {
            string firstColumn = ChessSquareLocation.AvailableColumns.First();
            var rect = ChessBoardPositionFinder.GetRectangle(firstColumn + row, SquareSize);
            SpriteBatch.Draw(_numbersTextures[row],
                new Rectangle(rect.X - SquareSize, rect.Y, SquareSize, SquareSize), MyGame.TransparencyColor);
        }
    }
}
