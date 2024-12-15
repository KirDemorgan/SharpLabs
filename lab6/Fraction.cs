namespace lab6;

public class Fraction : ICloneable, IFraction
{
    private int _numerator;
    private int _denominator;

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Значение знаменателя не может быть равно 0");
        }
        if (denominator < 0) {
            numerator = -numerator;
            denominator = -denominator;
        }
        _numerator = numerator;
        _denominator = denominator;
    }

    public int Denominator => _denominator;
    public int Numerator => _numerator;

    public override bool Equals(object? obj)
    {
        if (obj is Fraction fraction)
        {
            return _numerator == fraction._numerator && _denominator == fraction._denominator;
        }
        return false;
    }

    public override string ToString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public object Clone()
    {
        return new Fraction(_numerator, _denominator);
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        int numerator = a._numerator * b._denominator + b._numerator * a._denominator;
        int denominator = a._denominator * b._denominator;
        return new Fraction(numerator, denominator);
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        int numerator = a._numerator * b._denominator - b._numerator * a._denominator;
        int denominator = a._denominator * b._denominator;
        return new Fraction(numerator, denominator);
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        int numerator = a._numerator * b._numerator;
        int denominator = a._denominator * b._denominator;
        return new Fraction(numerator, denominator);
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        if (b._numerator == 0)
        {
            throw new ArgumentException("Деление на ноль");
        }
        int numerator = a._numerator * b._denominator;
        int denominator = a._denominator * b._numerator;
        return new Fraction(numerator, denominator);
    }

    public static Fraction operator +(Fraction a, int b)
    {
        return a + new Fraction(b, 1);
    }

    public static Fraction operator -(Fraction a, int b)
    {
        return a - new Fraction(b, 1);
    }

    public static Fraction operator *(Fraction a, int b)
    {
        return a * new Fraction(b, 1);
    }

    public static Fraction operator /(Fraction a, int b)
    {
        return a / new Fraction(b, 1);
    }

    public double GetFinalValue()
    {
        return (double)_numerator / _denominator;
    }

    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }

    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Значение знаменателя не может быть равно 0");
        }
        _denominator = denominator;
    }
}