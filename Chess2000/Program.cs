using BoardGame.Board;
using BoardGame.Board.Chess;
using BoardGame.Game;
using BoardGame.Game.Chess;
using BoardGame.SquaresLocation.Chess;
using BoardGame.Movements.Chess;
using System.Linq;
using BoardGame.MovementsProviders;

IGame chessGame = new ChessGame();
System.Diagnostics.Debug.WriteLine(chessGame.ToString());

if (!chessGame.GetAvailablePlayers().ElementAt(1).TryGetPiece(new ChessSquareLocation("E4"), out var piece)) return;
var moves = piece.GetAvailableMoves(chessGame);
chessGame.ExecuteMove(piece, moves.First(m => m is ChessMovementBase));
System.Diagnostics.Debug.WriteLine(chessGame.ToString());

using var game = new Chess2000.MyGame();
game.Run();
