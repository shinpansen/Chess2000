﻿using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Game.Chess;
using Chess2000.BoardGame.Location.Chess;
using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares.Chess;
using System.Collections.Generic;
using System.Linq;

/*ChessPiece p1 = new BlackPawn();
ChessPiece p2 = new BlackPawn();
var test = p1.IsFriend(new ChessPieceColorVisitor(p2));

ChessBoard board = new();
board.Squares[0].Piece = new BlackPawn();
board.Squares[1].Piece = new WhitePawn();
var rules = new ChessMovementRules(board.Squares[0], board);
rules.GetAvailableMoves();*/

IBoard board = new ChessBoard();
IGame chessGame = new ChessGame();

if (!chessGame.TryGetPiece(new ChessSquareLocation("A2"), out var piece)) return;
ChessMovementsRules rules = new ChessMovementsRules(chessGame, board, piece);
List<IMovement> moves = piece.GetAvailableMoves(rules);
chessGame.ExecuteMove(moves.First(), rules);

using var game = new Chess2000.MyGame();
game.Run();
