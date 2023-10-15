using Chess2000.Window.Chess;

namespace Chess2000.Drawables;

public abstract class ChessDrawable : Drawable
{
    protected ChessBoardPositionFinder ChessBoardPositionFinder { get; private set; }

    protected ChessDrawable(GraphicsManager graphicsManager) : base(graphicsManager)
    {
        ChessBoardPositionFinder = new ChessBoardPositionFinder(graphicsManager.GraphicsDevice);
    }
}