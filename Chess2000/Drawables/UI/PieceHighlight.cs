using System;
using Chess2000.Drawables.Chess;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Chess2000.Drawables.Chess.ChessPiece;

namespace Chess2000.Drawables.UI;

public class PieceHighlight : ChessDrawable
{
    public override int DrawOrder => 1;
    public override event EventHandler<EventArgs> DrawOrderChanged;
    public override event EventHandler<EventArgs> VisibleChanged;

    private string _location { get; set; }
    private Texture2D _texture2D { get; set; }

    public PieceHighlight(GraphicsManager graphicsManager, string location, ChessPiece piece) : base(graphicsManager)
    {
        _location = location;
        _texture2D = Content.Load<Texture2D>("UI/Actions/Select" + (piece.Color == PieceColor.White ? "Black" : "White"));
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Begin();
        var rect = ChessBoardPositionFinder.GetRectangle(_location, ChessBoard.SquareSize);
        SpriteBatch.Draw(_texture2D, rect, MyGame.TransparencyColor);
        SpriteBatch.End();
    }
}