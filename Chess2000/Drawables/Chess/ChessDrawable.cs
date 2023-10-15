using Chess2000.Window.Chess;

namespace Chess2000.Drawables.Chess;

public abstract class ChessDrawable : Drawable
{
    protected ChessBoardPositionFinder ChessBoardPositionFinder { get; private set; }
    
    protected ChessDrawable(DrawTools drawTools) : base(drawTools)
    {
        ChessBoardPositionFinder = new ChessBoardPositionFinder(drawTools.GraphicsDevice);
    }
}