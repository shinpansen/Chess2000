using BoardGame.Board;
using BoardGame.Board.Chess;
using BoardGame.Game;
using BoardGame.Game.Chess;
using BoardGame.SquaresLocation.Chess;
using BoardGame.Movements.Chess;
using System.Linq;
using BoardGame.MovementsProviders;

IBoard board = new ChessBoard();
IGame chessGame = new ChessGame();

if (!chessGame.TryGetPiece(new ChessSquareLocation("D2"), out var piece)) return;
var moves = piece.GetAvailableMoves(chessGame, board);
chessGame.ExecuteMove(piece, moves.First(), board);

using var game = new Chess2000.MyGame();
game.Run();
