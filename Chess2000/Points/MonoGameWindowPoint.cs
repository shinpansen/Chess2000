using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.Points
{
    internal class MonoGameWindowPoint
    {
        private GraphicsDevice _graphicsDevice { get; set; }

        public MonoGameWindowPoint(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public Point GetCenterScreenPoint()
        {
            int w = _graphicsDevice.Viewport.Width;
            int h = _graphicsDevice.Viewport.Height;
            return new Point(w / 2, h / 2);
        }
    }
}
