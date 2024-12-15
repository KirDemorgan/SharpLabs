namespace lab6;

public class CachedFraction : IFraction
{
    private readonly IFraction _fraction;
    private double? _cachedRealValue;

    public CachedFraction(IFraction fraction)
    {
        _fraction = fraction;
        _cachedRealValue = null;
    }

    public double GetFinalValue()
    {
        if (_cachedRealValue == null)
        {
            _cachedRealValue = _fraction.GetFinalValue();
        }
        return _cachedRealValue.Value;
    }

    public void SetNumerator(int numerator)
    {
        _fraction.SetNumerator(numerator);
        _cachedRealValue = null;
    }

    public void SetDenominator(int denominator)
    {
        _fraction.SetDenominator(denominator);
        _cachedRealValue = null;
    }
}