using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Chess2000.BoardGame.Squares.Chess;

public class ChessSquareLocation : ISquareLocation<ChessSquareLocation>
{
    public static readonly string[] AvailableColumns = new[] { "A", "B", "C", "D", "E", "F", "G", "H" };
    public static readonly ushort[] FirstRows = new ushort[] { 1, 8 };
    public int Row { get; private set; }
    public string Column { get; private set; }

    public ChessSquareLocation(string column, int row)
    {
        if (row < 1 || row > 8 || !AvailableColumns.Contains(column.ToUpper()))
            throw new ArgumentException("Invalid row or column");

        Row = row;
        Column = column.ToUpper();
    }

    public Point ToPoint()
    {
        return new Point(Array.IndexOf(AvailableColumns, Column) + 1, Row);
    }

    public bool Equals(ChessSquareLocation other)
    {
        return this.ToString().Equals(other.ToString());
    }

    public override string ToString()
    {
        return Column + Row.ToString();
    }
}