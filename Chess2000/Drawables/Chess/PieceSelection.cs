using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess2000.Drawables.Chess;

public class PieceSelection : ChessDrawable
{
    public override int DrawOrder => 1;
    public override bool Visible => true;
    public override event EventHandler<EventArgs> DrawOrderChanged;
    public override event EventHandler<EventArgs> VisibleChanged;

    private string _location {  get; set; }
    private Texture2D _texture2D {  get; set; }
    
    public PieceSelection(DrawTools drawTools, string location) : base(drawTools)
    {
        _location = location;
        _texture2D = Content.Load<Texture2D>("UI/Actions/Select");
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Begin();
        var rect = ChessBoardPositionFinder.GetRectangle(_location, ChessBoard.SquareSize);
        SpriteBatch.Draw(_texture2D, rect, MyGame.TransparencyColor);
        SpriteBatch.End();
    }
}