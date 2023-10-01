using System;
using System.Collections.Generic;
using System.Linq;
using BoardGame.SquaresLocation.Links;
using BoardGame.SquaresLocation.Links._2DGrid;

namespace BoardGame.SquaresLocation.Chess;

public class ChessSquareLocation : SquareLocation
{
    public static readonly string[] AvailableColumns = { "A", "B", "C", "D", "E", "F", "G", "H" };
    public int Row { get; private set; }
    public string Column { get; private set; }

    public ChessSquareLocation(string location)
    {
        if (location.Length != 2 || !int.TryParse(location.AsSpan(1, 1), out var row))
            throw new ArgumentException("Invalid location");
        if (row < 1 || row > 8 || !AvailableColumns.Contains(location[..1].ToUpper()))
            throw new ArgumentException("Invalid row or column");

        Row = row;
        Column = location[..1];
    }

    public ChessSquareLocation(int column, int row)
    {
        if (row < 1 || row > 8 || column < 0 || column > AvailableColumns.Length)
            throw new ArgumentException("Invalid row or column");

        Row = row;
        Column = AvailableColumns[column - 1];
    }

    public override Dictionary<ISquareLink, ISquareLocation> GetNeighbors()
    {
        var x = this.ToPoint2D().X;
        Dictionary<ISquareLink, ISquareLocation> locations = new();
        if (x > 1) locations.Add(new Left(), new ChessSquareLocation(x - 1, Row));
        if (x < 8) locations.Add(new Right(), new ChessSquareLocation(x + 1, Row));
        if (Row < 8) locations.Add(new Top(), new ChessSquareLocation(x, Row + 1));
        if (Row > 1) locations.Add(new Bottom(), new ChessSquareLocation(x, Row - 1));
        if (x > 1 && Row < 8) locations.Add(new TopLeft(), new ChessSquareLocation(x - 1, Row + 1));
        if (x < 8 && Row < 8) locations.Add(new TopRight(), new ChessSquareLocation(x + 1, Row + 1));
        if (x > 1 && Row > 1) locations.Add(new BottomLeft(), new ChessSquareLocation(x - 1, Row - 1));
        if (x < 8 && Row > 1) locations.Add(new BottomRight(), new ChessSquareLocation(x + 1, Row - 1));
        return locations;
    }

    public override bool Equals(ISquareLocation? other)
    {
        if (other is not ChessSquareLocation l) return false;
        return l.Column.Equals(Column) && l.Row.Equals(Row);
    }

    public override string ToString()
    {
        return Column + Row;
    }

    private Point2D ToPoint2D()
    {
        return new Point2D(Array.IndexOf(AvailableColumns, Column) + 1, Row);
    }
}
