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

namespace BoardGame.Rules;

public abstract class MovementsRules : IMovementsRules
{
    protected IGame Game { get; set; }
    protected IBoard Board { get; set; }
    protected IPiece Piece { get; set; }
    private List<IMovement> _availableMoves { get; set; }

    protected MovementsRules(IGame game, IBoard board, IPiece piece)
    {
        Game = game;
        Board = board;
        Piece = piece;
        _availableMoves = Piece.GetAvailableMoves(this);
    }
    
    public virtual ReadOnlyCollection<IMovement> GetAvailableMoves()
    {
        return _availableMoves.AsReadOnly();
    }
}
