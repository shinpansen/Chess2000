using BoardGame.SquaresLocation.Chess;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chess2000.Window.Chess
{
    public class ChessBoardPositionFinder
    {
        private GraphicsDevice _graphicsDevice { get; set; }

        public ChessBoardPositionFinder(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }
        
        public Rectangle GetRectangle(string location, int squareSize)
        {
            if (!Regex.IsMatch(location!, "[A-H][1-8]"))
                throw new Exception("Invalid location");

            int row = int.Parse(location[1..]);
            int column = Array.IndexOf(ChessSquareLocation.AvailableColumns, location[..1]);
            var viewPort = new ViewPort(_graphicsDevice);
            
            int centerX = _graphicsDevice.Viewport.Width / 2;
            int centerY = _graphicsDevice.Viewport.Height / 2;

            float halfBoardSize = (squareSize * 8f) / 2f;
            return new Rectangle(
                centerX + (column * squareSize) - (int)halfBoardSize,
                centerY + ((8 - row) * squareSize) - (int)halfBoardSize,
                squareSize,
                squareSize
            );
        }
    }
}
