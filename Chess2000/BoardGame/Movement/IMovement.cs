using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Rules;

namespace Chess2000.BoardGame.Movement;

public interface IMovement
{
    public void ExecuteMove();
}