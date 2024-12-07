namespace AdventOfCode.Helpers;

public struct Coords
{
    public int X;
    public int Y;

    public static Coords operator +(Coords c1, Coords c2)
    {
        return new Coords { X = c1.X + c2.X, Y = c1.Y + c2.Y };
    }
    
    public static Coords operator *(Coords c, int scalar)
    {
        return new Coords { X = c.X * scalar, Y = c.Y * scalar };
    }

    public static Coords operator -(Coords c1, Coords c2)
    {
        return new Coords { X = c1.X - c2.X, Y = c1.Y - c2.Y };
    }
}