using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.Window
{
    public class ViewPort
    {
        public int Width => _graphicsDevice.Viewport.Width;
        public int Height => _graphicsDevice.Viewport.Height;
        private GraphicsDevice _graphicsDevice { get; set; }

        public ViewPort(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public Point GetCenterPoint()
        {
            return new Point(Width / 2, Height / 2);
        }
    }
}
