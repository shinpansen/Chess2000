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
    internal class GameBoardLocation
    {
        public Rectangle Rectangle { get; private set; }
        private GraphicsDevice _graphicsDevice { get; set; }
        private string _location { get; set; }
        private int _squareSize { get; set; }

        public GameBoardLocation(GraphicsDevice graphicsDevice, string location, int squareSize)
        {
            if (!Regex.IsMatch(location!, "[A-H][1-8]"))
                throw new Exception("Invalid location");

            _graphicsDevice = graphicsDevice;
            _location = location;
            _squareSize = squareSize;

            int row = int.Parse(_location[1..]);
            int column = Array.IndexOf(ChessSquareLocation.AvailableColumns, _location[..1]);
            var viewPort = new ViewPort(_graphicsDevice);

            float halfBoardSize = (_squareSize * 8f) / 2f;
            Rectangle = new Rectangle(
                viewPort.GetCenterPoint().X + (column * _squareSize) - (int)halfBoardSize,
                viewPort.GetCenterPoint().Y + ((8 - row) * _squareSize) - (int)halfBoardSize,
                _squareSize,
                _squareSize
            );
        }
    }
}
