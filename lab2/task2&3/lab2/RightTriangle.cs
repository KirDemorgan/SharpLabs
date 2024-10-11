namespace lab2;

public class RightTriangle
{
    private double _a;
    private double _b;

    public double A
    {
        get => _a;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Side must be greater than 0");
            }
            _a = value;
        }
    }

    public double B
    {
        get => _b;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Side must be greater than 0");
            }
            _b = value;
        }
    }

    public RightTriangle(double a, double b)
    {
        this.A = a;
        this.B = b;
    }

    public RightTriangle()
    {
        A = 1;
        B = 1;
    }

    public double CalculateArea()
    {
        return 0.5 * _a * _b;
    }

    public static RightTriangle operator ++(RightTriangle triangle)
    {
        triangle.A *= 2;
        triangle.B *= 2;
        return triangle;
    }

    public static RightTriangle operator --(RightTriangle triangle)
    {
        if (triangle.A / 2 <= 0 || triangle.B / 2 <= 0)
        {
            throw new InvalidOperationException("Cannot decrement sides below or equal to zero");
        }
        triangle.A /= 2;
        triangle.B /= 2;
        return triangle;
    }

    public static explicit operator double(RightTriangle triangle)
    {
        return triangle.A > 0 && triangle.B > 0 ? triangle.CalculateArea() : -1;
    }

    public static implicit operator bool(RightTriangle triangle)
    {
        return triangle.A > 0 && triangle.B > 0;
    }

    public static bool operator <=(RightTriangle t1, RightTriangle t2)
    {
        return t1.CalculateArea() <= t2.CalculateArea();
    }

    public static bool operator >=(RightTriangle t1, RightTriangle t2)
    {
        return t1.CalculateArea() >= t2.CalculateArea();
    }

    public override string ToString()
    {
        return $"RightTriangle: a = {A}, b = {B}";
    }
}