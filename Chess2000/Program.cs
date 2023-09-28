
using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Game;
using Chess2000.BoardGame.Game.Chess;
using Chess2000.BoardGame.Location.Chess;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares.Chess;
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
IGame<ChessPiece> chessGame = new ChessGame();

var piece = chessGame.GetAvailablePieces().First();
var moves = piece.GetAvailableMoves(new ChessMovementsRules(chessGame, board, piece));
piece.ExecuteAction(moves.First());

using var game = new Chess2000.MyGame();
game.Run();
