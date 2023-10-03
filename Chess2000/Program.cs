using BoardGame.Board;
using BoardGame.Board.Chess;
using BoardGame.Game;
using BoardGame.Game.Chess;
using BoardGame.SquaresLocation.Chess;
using BoardGame.Movements.Chess;
using System.Linq;
using BoardGame.MovementsProviders;

IGame chessGame = new ChessGame();

if (!chessGame.GetAvailablePlayers().First().TryGetPiece(new ChessSquareLocation("D7"), out var piece)) return;
var moves = piece.GetAvailableMoves(chessGame, chessGame.Board);
chessGame.ExecuteMove(piece, moves.First());

using var game = new Chess2000.MyGame();
game.Run();
