using Chess2000.BoardGame.Board;
using Chess2000.BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Pieces
{
    public interface IPiece<TS, TSl> 
        where TS : ISquare<TSl> 
        where TSl : ISquareLocation<TSl>
    {
        TS Square { get; }
    }
}
