using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Chess2000.Drawables;

public abstract class Drawable : IDrawable
{
    protected GraphicsDevice GraphicsDevice { get; set; }
    protected ContentManager Content { get; set; }
    protected SpriteBatch SpriteBatch { get; set; }
    
    protected Drawable(DrawTools drawTools)
    {
        GraphicsDevice = drawTools.GraphicsDevice;
        Content = drawTools.Content;
        SpriteBatch = drawTools.SpriteBatch;
    }
    public abstract void Draw(GameTime gameTime);
    public abstract int DrawOrder { get; }
    public abstract bool Visible { get; }
    public abstract event EventHandler<EventArgs> DrawOrderChanged;
    public abstract event EventHandler<EventArgs> VisibleChanged;
}