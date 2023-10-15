using System;
using Chess2000.Window.Chess;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Chess2000.Drawables;

public abstract class Drawable : IDrawable
{
    public bool Visible => _visible;

    protected GraphicsDevice GraphicsDevice { get; set; }
    protected ContentManager Content { get; set; }
    protected SpriteBatch SpriteBatch { get; set; }

    private bool _visible = true;

    protected Drawable(GraphicsManager graphicsManager)
    {
        GraphicsDevice = graphicsManager.GraphicsDevice;
        Content = graphicsManager.Content;
        SpriteBatch = graphicsManager.SpriteBatch;
    }

    public void Show() => _visible = true;
    public void Hide() => _visible = false;
    
    public abstract void Draw(GameTime gameTime);
    public abstract int DrawOrder { get; }
    public abstract event EventHandler<EventArgs> DrawOrderChanged;
    public abstract event EventHandler<EventArgs> VisibleChanged;
}