using BoardGame.Pieces.Chess;
using BoardGame.Squares.Chess;
using BoardGame.SquaresLocation.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGame.Board.Chess;
using BoardGame.Movements;
using BoardGame.MovementsProviders;
using BoardGame.Pieces;
using System.Collections.ObjectModel;
using BoardGame.Board;
using BoardGame.Players;
using BoardGame.Players.Chess;
using BoardGame.SquaresLocation;
using BoardGame.SquaresLocation.Links._2DGrid;

namespace BoardGame.Game.Chess;

public class ChessGame : Game
{
    public override bool IsRunning => CountAvailableMovesForCurrentPlayer() > 0;
    public override IBoard Board { get; }
    private IPlayer _playerOne { get; set; }
    private IPlayer _playerTwo { get; set; }
    private IPlayer _currentPlayer { get; set; }

    public ChessGame()
    {
        //Board
        Board = new ChessBoard();
        
        //Pieces
        var playerOnePieces = new List<IPiece>();
        var playerTwoPieces = new List<IPiece>();
        
        //Pawns
        foreach(var col in ChessSquareLocation.AvailableColumns)
        {
            playerOnePieces.Add(new Pawn(col + "2", new Top()));
            playerTwoPieces.Add(new Pawn(col + "7", new Bottom()));
        }
        
        //Black pieces
        playerTwoPieces.Add(new Tower("A8"));
        playerTwoPieces.Add(new Knight("B8"));
        playerTwoPieces.Add(new Bishop("C8"));
        playerTwoPieces.Add(new Queen("D8"));
        playerTwoPieces.Add(new King("E8"));
        playerTwoPieces.Add(new Bishop("F8"));
        playerTwoPieces.Add(new Knight("G8"));
        playerTwoPieces.Add(new Tower("H8"));
        
        //White pieces
        playerOnePieces.Add(new Tower("A1"));
        playerOnePieces.Add(new Knight("B1"));
        playerOnePieces.Add(new Bishop("C1"));
        playerOnePieces.Add(new Queen("D1"));
        playerOnePieces.Add(new King("E1"));
        playerOnePieces.Add(new Bishop("F1"));
        playerOnePieces.Add(new Knight("G1"));
        playerOnePieces.Add(new Tower("H1"));

        //Players
        _playerOne = new ChessPlayer(playerOnePieces);
        _playerTwo = new ChessPlayer(playerTwoPieces);
        _currentPlayer = _playerOne;
    }
    
    public override ReadOnlyCollection<IPlayer> GetAvailablePlayers()
    {
        return new List<IPlayer>() { _playerOne, _playerTwo }.AsReadOnly();
    }

    public override ReadOnlyCollection<IPlayer> GetCurrentPlayers()
    {
        return new List<IPlayer>() { _currentPlayer }.AsReadOnly();
    }

    public override void ExecuteMove(IPiece piece, IMovement move)
    {
        VerifyMove(piece, move);
        _playerOne = new ChessPlayer(move.SimulateMove(this, _playerOne));
        _playerTwo = new ChessPlayer(move.SimulateMove(this, _playerTwo));
        _currentPlayer = _currentPlayer == _playerOne ? _playerTwo : _playerOne;
    }

    private int CountAvailableMovesForCurrentPlayer()
    {
        return _currentPlayer.GetAvailablePieces().Sum(piece => piece.GetAvailableMoves(this, Board).Count);
    }
}
