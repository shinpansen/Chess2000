using BoardGame.Movements;
using BoardGame.Squares;

namespace BoardGame.Pieces
{
    public interface ICloneablePiece<out TPiece, in TSquare, in TMovement>
    {
        public TPiece Clone();
        public TPiece Clone(TSquare newSquare);
        public TPiece Clone(TSquare newSquare, TMovement? move);
    }
}
