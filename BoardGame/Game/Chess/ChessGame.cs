using BoardGame.Pieces.Chess;
using BoardGame.Squares.Chess;
using BoardGame.SquaresLocation.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGame.Board.Chess;
using BoardGame.Movements;
using BoardGame.MovementsProviders;
using BoardGame.Pieces;

namespace BoardGame.Game.Chess;

public class ChessGame : Game
{
    public ChessGame()
    {
        //Pawns
        foreach(var col in ChessSquareLocation.AvailableColumns)
        {
            AvailablePieces.Add(new BlackPawn(col + "7"));
            AvailablePieces.Add(new WhitePawn(col + "2"));
        }
        
        //Black pieces
        AvailablePieces.Add(new BlackTower("A8"));
        AvailablePieces.Add(new BlackKnight("B8"));
        AvailablePieces.Add(new BlackBishop("C8"));
        AvailablePieces.Add(new BlackQueen("D8"));
        AvailablePieces.Add(new BlackKing("E8"));
        AvailablePieces.Add(new BlackBishop("F8"));
        AvailablePieces.Add(new BlackKnight("G8"));
        AvailablePieces.Add(new BlackTower("H8"));
        
        //White pieces
        AvailablePieces.Add(new WhiteTower("A1"));
        AvailablePieces.Add(new WhiteKnight("B1"));
        AvailablePieces.Add(new WhiteBishop("C1"));
        AvailablePieces.Add(new WhiteQueen("D1"));
        AvailablePieces.Add(new WhiteKing("E1"));
        AvailablePieces.Add(new WhiteBishop("F1"));
        AvailablePieces.Add(new WhiteKnight("G1"));
        AvailablePieces.Add(new WhiteTower("H1"));
    }
}
