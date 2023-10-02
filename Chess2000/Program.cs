using BoardGame.Board;
using BoardGame.Board.Chess;
using BoardGame.Game;
using BoardGame.Game.Chess;
using BoardGame.SquaresLocation.Chess;
using BoardGame.Movements.Chess;
using System.Linq;
using BoardGame.MovementsRules;

IBoard board = new ChessBoard();
IGame chessGame = new ChessGame();

if (!chessGame.TryGetPiece(new ChessSquareLocation("D2"), out var piece)) return;
var rules = new MovementsRules(chessGame, board);
var moves = rules.GetAvailableMoves(piece);
piece.GetAvailableMoves(null);
chessGame.ExecuteMove(piece, moves.First(), rules);

using var game = new Chess2000.MyGame();
game.Run();
