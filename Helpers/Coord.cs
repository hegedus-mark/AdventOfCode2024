using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Helpers;

public struct Coord : IEquatable<Coord>
{
    public int X;
    public int Y;

    public static Coord operator +(Coord c1, Coord c2)
    {
        return new Coord { X = c1.X + c2.X, Y = c1.Y + c2.Y };
    }
    
    public static Coord operator *(Coord c, int scalar)
    {
        return new Coord { X = c.X * scalar, Y = c.Y * scalar };
    }

    public static Coord operator -(Coord c1, Coord c2)
    {
        return new Coord { X = c1.X - c2.X, Y = c1.Y - c2.Y };
    }


    public bool Equals(Coord other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        return obj is Coord other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}