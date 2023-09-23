
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules.Chess;

ChessPiece p1 = new BlackPawn();
ChessPiece p2 = new BlackPawn();
var test = p1.IsFriend(new ChessPieceVisitor(p2));

using var game = new Chess2000.MyGame();
game.Run();
