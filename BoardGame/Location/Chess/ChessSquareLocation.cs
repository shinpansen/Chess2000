using System;
using System.Collections.Generic;
using System.Linq;
using Chess2000.BoardGame.Location.Links;
using Chess2000.BoardGame.Location.Links._2DGrid;

namespace Chess2000.BoardGame.Location.Chess;

public class ChessSquareLocation : SquareLocation
{
    public static readonly string[] AvailableColumns = { "A", "B", "C", "D", "E", "F", "G", "H" };
    private int _row { get; set; }
    private string _column { get; set; }

    public ChessSquareLocation(string location)
    {
        if (location.Length != 2 || !int.TryParse(location.AsSpan(1, 1), out var row))
            throw new ArgumentException("Invalid location");
        if (row < 1 || row > 8 || !AvailableColumns.Contains(location[..1].ToUpper()))
            throw new ArgumentException("Invalid row or column");

        _row = row;
        _column = location[..1];
    }

    private ChessSquareLocation(int column, int row)
    {
        if (row < 1 || row > 8 || column < 0 || column > AvailableColumns.Length)
            throw new ArgumentException("Invalid row or column");

        _row = row;
        _column = AvailableColumns[column - 1];
    }

    public override Dictionary<ISquareLink, ISquareLocation> GetNeighbors()
    {
        var x = this.ToPoint2D().X;
        Dictionary<ISquareLink, ISquareLocation> locations = new();
        if (x > 1) locations.Add(new Left(), new ChessSquareLocation(x - 1, _row));
        if (x < 8) locations.Add(new Right(), new ChessSquareLocation(x + 1, _row));
        if (_row < 8) locations.Add(new Top(), new ChessSquareLocation(x, _row + 1));
        if (_row > 1) locations.Add(new Bottom(), new ChessSquareLocation(x, _row - 1));
        if (x > 1 && _row < 8) locations.Add(new TopLeft(), new ChessSquareLocation(x - 1, _row + 1));
        if (x < 8 && _row < 8) locations.Add(new TopRight(), new ChessSquareLocation(x + 1, _row + 1));
        if (x > 1 && _row > 1) locations.Add(new BottomLeft(), new ChessSquareLocation(x - 1, _row - 1));
        if (x < 8 && _row > 1) locations.Add(new BottomRight(), new ChessSquareLocation(x + 1, _row - 1));
        return locations;
    }

    public override string ToString()
    {
        return _column + _row;
    }

    private Point2D ToPoint2D()
    {
        return new Point2D(Array.IndexOf(AvailableColumns, _column) + 1, _row);
    }
}
