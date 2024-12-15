namespace lab6;

public class MeowCounter : IMeowable
{
    private readonly IMeowable _meowable;
    private int _meowCount;

    public MeowCounter(IMeowable meowable)
    {
        _meowable = meowable;
        _meowCount = 0;
    }

    public void Meow()
    {
        _meowable.Meow();
        _meowCount++;
    }

    public void Meow(int times)
    {
        _meowable.Meow(times);
        _meowCount += times;
    }

    public int GetMeowCount()
    {
        return _meowCount;
    }

    public IMeowable Meowable => _meowable;
}