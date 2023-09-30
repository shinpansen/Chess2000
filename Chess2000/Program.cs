using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Game.Chess;
using Chess2000.BoardGame.Location.Chess;
using Chess2000.BoardGame.Movements.Chess;
using Chess2000.BoardGame.Rules.Chess;
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
ChessMovementsRules rules = new ChessMovementsRules(chessGame, board, piece);
var moves = rules.GetAvailableMoves();
chessGame.ExecuteMove(moves.First(m => m is ChessMovementPawnDouble), rules);

rules = new ChessMovementsRules(chessGame, board, piece);
moves = rules.GetAvailableMoves();

using var game = new Chess2000.MyGame();
game.Run();
