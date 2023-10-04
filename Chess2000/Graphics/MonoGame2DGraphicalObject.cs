using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.Graphics
{
    internal abstract class MonoGame2DGraphicalObject : IMonoGame2DGraphicalObject
    {
        protected GraphicsDevice GraphicsDevice { get; set; }
        protected SpriteBatch SpriteBatch { get; set; }

        public MonoGame2DGraphicalObject(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            GraphicsDevice = graphicsDevice;
            SpriteBatch = spriteBatch;
        }

        public abstract void Draw(Point centerPoint, ContentManager content);
    }
}
