using BoardGame.Board;
using BoardGame.Board.Chess;
using BoardGame.Game;
using BoardGame.Game.Chess;
using BoardGame.Location.Chess;
using BoardGame.Movements.Chess;
using BoardGame.Rules.Chess;
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

if (!chessGame.TryGetPiece(new ChessSquareLocation("B2"), out var piece)) return;
var rules = new ChessMovementsRules(chessGame, board, piece);
var moves = rules.GetAvailableMoves();
moves.First().SimulateMove(chessGame);
chessGame.ExecuteMove(moves.First(m => m is ChessMovementBase), rules);

if (!chessGame.TryGetPiece(new ChessSquareLocation("B3"), out var piece2)) return;
rules = new ChessMovementsRules(chessGame, board, piece2);
moves = rules.GetAvailableMoves();

using var game = new Chess2000.MyGame();
game.Run();
