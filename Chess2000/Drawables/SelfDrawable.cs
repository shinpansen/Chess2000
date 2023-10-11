using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.Drawables
{
    internal abstract class SelfDrawable
    {
        protected GraphicsDevice GraphicsDevice { get; set; }
        protected SpriteBatch SpriteBatch { get; set; }
        protected ContentManager Content { get; set; }

        protected SelfDrawable(GraphicsDevice graphicsDevice, ContentManager content)
        {
            GraphicsDevice = graphicsDevice;
            Content = content;
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }
    }
}
