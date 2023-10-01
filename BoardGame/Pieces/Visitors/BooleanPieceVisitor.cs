using BoardGame.Data;
using BoardGame.Pieces.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Pieces.Visitors;

public class BooleanPieceVisitor
{
    private readonly IPiece _visitedPiece;

    public BooleanPieceVisitor(IPiece visitedPiece)
    {
        _visitedPiece = visitedPiece;
    }

    public bool Visit(BlackPiece p1) => _visitedPiece is BlackPiece;

    public bool Visit(WhitePiece p1) => _visitedPiece is WhitePiece;

    /*public IData Visit(BlackPiece p1)
    {
        var data = new Data.Data("IsFriend", _visitedPiece is BlackPiece);
        data.Add(_visitedPiece.GetData());
        return data;
    }

    public IData Visit(WhitePiece p1)
    {
        var data = new Data.Data("IsFriend", _visitedPiece is WhitePiece);
        data.Add(_visitedPiece.GetData());
        return data;
    }*/
}
