using BoardGame.Board;
using BoardGame.Board.Chess;
using BoardGame.Game;
using BoardGame.Game.Chess;
using BoardGame.SquaresLocation.Chess;
using BoardGame.Movements.Chess;
using BoardGame.MovementsRules.Chess;
using System.Linq;

IBoard board = new ChessBoard();
IGame chessGame = new ChessGame();

if (!chessGame.TryGetPiece(new ChessSquareLocation("B7"), out var piece)) return;
var rules = new ChessMovementsRules(chessGame, board, piece);
var moves = rules.GetAvailableMoves();
moves.First().SimulateMove(chessGame);
chessGame.ExecuteMove(moves.First(m => m is ChessMovementBase), rules);

using var game = new Chess2000.MyGame();
game.Run();
