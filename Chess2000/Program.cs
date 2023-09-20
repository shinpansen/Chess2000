
using Chess2000.BoardGame.Pieces.Chess;

ChessPiece p1 = new BlackPawn();
ChessPiece p2 = new WhitePawn();
var test = p1.IsFriend(p2);

using var game = new Chess2000.MyGame();
game.Run();
