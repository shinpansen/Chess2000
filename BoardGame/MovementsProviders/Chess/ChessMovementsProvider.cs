using BoardGame.Board;
using BoardGame.Game;
using BoardGame.SquaresLocation.Links;
using BoardGame.Pieces;
using BoardGame.Pieces.Visitors;
using BoardGame.Squares;
using System.Collections.Generic;
using System.Linq;
using BoardGame.SquaresLocation.Links._2DGrid;
using BoardGame.Movements;
using BoardGame.Pieces.Chess;
using BoardGame.Players.Chess;
using BoardGame.Game.Chess;

namespace BoardGame.MovementsProviders.Chess;

public abstract class ChessMovementsProvider : MovementsProvider
{
    public static readonly List<ISquareLink> StraightLinks = new List<ISquareLink>()
    {
        new Top(),
        new Bottom(),
        new Left(),
        new Right()
    };

    public static readonly List<ISquareLink> DiagonalLinks = new List<ISquareLink>()
    {
        new TopLeft(),
        new BottomLeft(),
        new TopRight(),
        new BottomRight()
    };

    protected List<IMovement> Moves {  get; set; }

    protected ChessMovementsProvider(IGame game, IBoard board, IPiece piece) : base(game, board, piece)
    {
        Moves = new List<IMovement>();
    }

    public override List<IMovement> GetAvailableMoves()
    {
        return Moves.Where(m => IsMoveSafeForTheKing(m)).ToList();
    }

    public override List<IMovement> SimulateAvailableMoves()
    {
        return Moves;
    }

    protected bool TryGetEmptySquare(Queue<ISquareLink> links, out ISquare square, bool pathShouldBeFree = false)
    {
        if(!TryGetSquare(links, out square, pathShouldBeFree)) return false;
        return !TryGetPiece(square.GetLocation(), out _);
    }

    protected bool TryGetSquareWithOpponent(Queue<ISquareLink> links, out ISquare square, bool pathShouldBeFree = false)
    {
        if (!TryGetLastSquareEmptyOrWithOpponent(links, out square, out var piece, pathShouldBeFree)) return false;
        return piece is not null && !IsFriend(piece);
    }

    protected bool TryGetSquareEmptyOrWithOpponent(Queue<ISquareLink> links, out ISquare square, bool pathShouldBeFree = false)
    {
        if (!TryGetLastSquareEmptyOrWithOpponent(links, out square, out var piece, pathShouldBeFree)) return false;
        return piece is null || !IsFriend(piece);
    }

    private bool TryGetLastSquareEmptyOrWithOpponent(Queue<ISquareLink> links, out ISquare square, out IPiece piece, bool pathShouldBeFree)
    {
        piece = default;
        //Test if there is an opponent on the last square of the path
        //If pathShouldBeFree is true, we cannot get the last square with a potential opponent
        var linksClone = new Queue<ISquareLink>(links);
        if (!TryGetSquare(links, out square, pathShouldBeFree))
        {
            if (links.Count > 1) return false;
            else if (!TryGetSquare(linksClone, out square)) return false;
        }
        TryGetPiece(square.GetLocation(), out piece);
        return true;
    }

    protected bool IsMoveSafeForTheKing(IMovement move) //Testing if move is gonna kill the king
    {
        //Simulating move
        var player = Game.GetAvailablePlayers().Where(p => p.TryGetPiece(Piece.Location, out _)).First();
        var otherPlayer = Game.GetAvailablePlayers().Where(p => !p.TryGetPiece(Piece.Location, out _)).First();
        var playerPiecesAfterMove = move.SimulateMove(Game, player);
        var otherPlayerPiecesAfterMove = move.SimulateMove(Game, otherPlayer);

        //New game simulated
        var newPlayer = new ChessPlayer(playerPiecesAfterMove);
        var newOtherPlayer = new ChessPlayer(otherPlayerPiecesAfterMove);
        var newGame = new ChessGame(newPlayer, newOtherPlayer);

        //Searching for a move available for the other player that can eat the king
        foreach (var piece in otherPlayerPiecesAfterMove)
        {
            var moves = piece.SimulateAvailableMoves(newGame, newGame.Board);
            foreach (var m in moves)
                if (!m.SimulateMove(newGame, newPlayer).Any(p => p is King)) //King is dead in this simulation
                    return false;
        }
        return true;
    }

    private bool IsFriend(IPiece other)
    {
        foreach(var player in Game.GetAvailablePlayers())
            if (player.TryGetPiece(Piece.Location, out _) && 
                player.TryGetPiece(other.Location, out _))
                return true;
        return false;
    }
}