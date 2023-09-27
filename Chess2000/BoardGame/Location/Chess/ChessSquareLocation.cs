using System;
using System.Collections.Generic;
using System.Linq;
using Chess2000.BoardGame.Location;
using Chess2000.BoardGame.Location.Links;
using Chess2000.BoardGame.Location.Links._2DGrid;
using Chess2000.BoardGame.Rules.Chess;

namespace Chess2000.BoardGame.Location.Chess;

public class ChessSquareLocation : ISquareLocation
{
    public static readonly string[] AvailableColumns = new[] { "A", "B", "C", "D", "E", "F", "G", "H" };
    public static readonly ushort[] FirstRows = new ushort[] { 1, 8 };
    private int _row { get; set; }
    private string _column { get; set; }

    public ChessSquareLocation(string column, int row)
    {
        if (row < 1 || row > 8 || !AvailableColumns.Contains(column.ToUpper()))
            throw new ArgumentException("Invalid row or column");

        _row = row;
        _column = column.ToUpper();
    }

    public ChessSquareLocation(int column, int row)
    {
        if (row < 1 || row > 8 || column < 0 || column > AvailableColumns.Length)
            throw new ArgumentException("Invalid row or column");

        _row = row;
        _column = AvailableColumns[column - 1];
    }

    public Point2D ToPoint2D()
    {
        return new Point2D(Array.IndexOf(AvailableColumns, _column) + 1, _row);
    }

    public bool Equals(ISquareLocation other)
    {
        return this.ToString().Equals(other.ToString());
    }

    public Dictionary<ISquareLink, ISquareLocation> GetNeighbors()
    {
        var x = this.ToPoint2D().X;
        Dictionary<ISquareLink, ISquareLocation> locations = new();
        if (x > 1) locations.Add(new Left(), new ChessSquareLocation(x - 1, _row));
        if (x < 8) locations.Add(new Right(), new ChessSquareLocation(x + 1, _row));
        if (_row > 1) locations.Add(new Top(), new ChessSquareLocation(_column, _row - 1));
        if (_row < 8) locations.Add(new Bottom(), new ChessSquareLocation(_column, _row + 1));
        return locations;
    }

    public ISquareLocation Clone()
    {
        return new ChessSquareLocation(_column, _row);
    }

    public override string ToString()
    {
        return _column + _row.ToString();
    }
}