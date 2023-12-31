﻿using BoardGame.Pieces.Chess;
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
using BoardGame.Movements.Chess;

namespace BoardGame.Game.Chess;

public class ChessGame : Game
{
    public override bool IsRunning => _currentPlayer.GetAvailablePieces().Sum(p => p.GetAvailableMoves(this).Count) > 0;
    public override IBoard Board { get; }

    private IPlayer _playerOne;
    private IPlayer _playerTwo;
    private IPlayer _currentPlayer;

    public ChessGame(IPlayer playerOne, IPlayer playerTwo)
    {
        //Board
        Board = new ChessBoard();

        _playerOne = playerOne;
        _playerTwo = playerTwo;
        _currentPlayer = _playerOne;
    }

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
        if (!_currentPlayer.TryGetPiece(piece.Location, out _))
            throw new ArgumentException("Piece does not belong to the current player");
        VerifyMove(piece, move);
        
        _currentPlayer.OnBeforeTurnStarts(this, EventArgs.Empty);
        int lastPlayer = _currentPlayer == _playerOne ? 1 : 2;
        _playerOne = new ChessPlayer(move.SimulateMove(this, _playerOne));
        _playerTwo = new ChessPlayer(move.SimulateMove(this, _playerTwo));
        _currentPlayer = lastPlayer == 1 ? _playerTwo : _playerOne;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        var squares = Board.GetAvailableSquares();
        for (int i = 8; i >= 1; i--)
        {
            sb.Append(i.ToString() +  " ");
            foreach (var square in squares.Where(s => s.ToString().Contains(i.ToString())).OrderBy(s => s.ToString()))
            {
                if(_playerOne.TryGetPiece(square.GetLocation(), out var p1Piece))
                    sb.Append("|1" + p1Piece.ToString());
                else if(_playerTwo.TryGetPiece(square.GetLocation(), out var p2Piece))
                    sb.Append("|2" + p2Piece.ToString());
                else sb.Append("|  ");
            }
            sb.Append('|');
            sb.AppendLine();
        }
        sb.Append("   A  B  C  D  E  F  G  H ");
        return sb.ToString();
    }
}
