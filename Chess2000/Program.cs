
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares.Chess;

/*ChessPiece p1 = new BlackPawn();
ChessPiece p2 = new BlackPawn();
var test = p1.IsFriend(new ChessPieceColorVisitor(p2));

ChessBoard board = new();
board.Squares[0].Piece = new BlackPawn();
board.Squares[1].Piece = new WhitePawn();
var rules = new ChessMovementRules(board.Squares[0], board);
rules.GetAvailableMoves();*/


using var game = new Chess2000.MyGame();
game.Run();
