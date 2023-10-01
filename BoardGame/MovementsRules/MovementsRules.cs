using BoardGame.Board;
using BoardGame.Game;
using BoardGame.Movements;
using BoardGame.Pieces;
using BoardGame.Pieces.Chess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.MovementsRules;

public class MovementsRules : IMovementsRules
{
    protected IGame Game { get; set; }
    protected IBoard Board { get; set; }

    public MovementsRules(IGame game, IBoard board)
    {
        Game = game;
        Board = board;
    }

    public IGame GetGame()
    {
        return Game;
    }

    public IBoard GetBoard()
    {
        return Board;
    }

    public virtual ReadOnlyCollection<IMovement> GetAvailableMoves(IPiece piece)
    {
        return piece.GetAvailableMoves(this).AsReadOnly();
    }
}
