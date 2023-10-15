using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Chess2000.Drawables;

public class GraphicsManager
{
    public readonly GraphicsDevice GraphicsDevice;
    public readonly ContentManager Content;
    public readonly SpriteBatch SpriteBatch;

    public GraphicsManager(GraphicsDevice graphicsDevice, ContentManager content, SpriteBatch spriteBatch)
    {
        GraphicsDevice = graphicsDevice;
        Content = content;
        SpriteBatch = spriteBatch;
    }
}