namespace lab6;

public class Cat : IMeowable
{
    private readonly string _name;

    public Cat(string name)
    {
        _name = name;
    }

    public string Name => _name;

    public void Meow()
    {
        Console.WriteLine($"{this}: мяу!");
    }

    public void Meow(int times)
    {
        if (times < 1)
        {
            throw new ArgumentException("Количество мяуканий должно быть больше 0");
        }

        string meow = "";
        for (int i = 0; i < times-1; i++)
        {
            meow += "мяу-";
        }

        meow += "мяу!";
        Console.WriteLine($"{this}: {meow}");
    }

    public override string ToString()
    {
        return $"кот: {_name}";
    }
}