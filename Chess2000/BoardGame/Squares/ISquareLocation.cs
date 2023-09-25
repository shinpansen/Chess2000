using System;
using System.Collections;
using System.Collections.Generic;

namespace Chess2000.BoardGame.Squares;

public interface ISquareLocation<TSl> : IEquatable<TSl> where TSl : ISquareLocation<TSl>
{
}