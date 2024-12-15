using System.Collections;
using System.Text;

namespace lab6;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        // Задание 1
        // 1 задача
        try
        {
            var cat = new Cat("Барсик");
            cat.Meow();
            cat.Meow(3);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            Console.WriteLine();
            Console.WriteLine();
            // 2 задача
            List<IMeowable> meowables = new List<IMeowable>();
            meowables.Add(new Cat("Барсик"));
            meowables.Add(new Cat("Широ"));
            meowables.Add(new Cat("Балбес"));

            meowables.Add(new Tiger("Мурзик"));
            meowables.Add(new Tiger("Маркиз"));

            MeowAll(meowables);

            Console.WriteLine();
            Console.WriteLine();
            // 3 задача

            List<IMeowable> meowables2 = new List<IMeowable>();
            meowables2.Add(new MeowCounter(new Cat("Барсик")));
            meowables2.Add(new MeowCounter(new Cat("Широ")));
            meowables2.Add(new MeowCounter(new Cat("Балбес")));

            Console.WriteLine();
            MeowAll(meowables2);

            foreach (var meowable in meowables2)
            {
                var meowCounter = (MeowCounter)meowable;
                var cat = (Cat)meowCounter.Meowable;
                Console.WriteLine($"{cat.Name} мяукал: {meowCounter.GetMeowCount()} раз");
            }

            Console.WriteLine();
            MeowAll(meowables2);

            foreach (var meowable in meowables2)
            {
                var meowCounter = (MeowCounter)meowable;
                var cat = (Cat)meowCounter.Meowable;
                Console.WriteLine($"{cat.Name} мяукал: {meowCounter.GetMeowCount()} раз");
            }

            Console.WriteLine();
            MeowAll(meowables2);

            foreach (var meowable in meowables2)
            {
                var meowCounter = (MeowCounter)meowable;
                var cat = (Cat)meowCounter.Meowable;
                Console.WriteLine($"{cat.Name} мяукал: {meowCounter.GetMeowCount()} раз");
            }

            Console.WriteLine();
            var senya = new MeowCounter(new Cat("Сеня"));
            senya.Meow(5);
            Console.WriteLine($"{senya.Meowable} мяукал: {senya.GetMeowCount()} раз");
            senya.Meow();
            Console.WriteLine($"{senya.Meowable} мяукал: {senya.GetMeowCount()} раз");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        // Задание 2
        // 1 задача
        Console.WriteLine("\nЗадание 2");
        try
        {
            var fraction1 = new Fraction(1, 3);
            var fraction2 = new Fraction(2, 3);
            var cachedFraction1 = new CachedFraction(fraction1);
            var cachedFraction2 = new CachedFraction(fraction2);

            Console.WriteLine($"{fraction1} + {fraction2} = " + (fraction1 + fraction2));
            Console.WriteLine($"{fraction1} - {fraction2} = " + (fraction1 - fraction2));
            Console.WriteLine($"{fraction1} * {fraction2} = " + (fraction1 * fraction2));
            Console.WriteLine($"{fraction1} / {fraction2} = " + (fraction1 / fraction2));
            Console.WriteLine($"{fraction1} + 1 = " + (fraction1 + 1));
            Console.WriteLine($"{fraction1} - 1 = " + (fraction1 - 1));

            var f1 = new Fraction(1, 3);
            var f2 = new Fraction(2, 3);
            var f3 = new Fraction(3, 4);

            Console.WriteLine();
            Console.WriteLine(f1 + f2 / f3 - 5);

            Console.WriteLine($"Кешированное значение {fraction1}: {cachedFraction1.GetFinalValue()}");
            Console.WriteLine($"Кешированное значение {fraction2}: {cachedFraction2.GetFinalValue()}");

            cachedFraction1.SetNumerator(2);
            Console.WriteLine($"Обновили {fraction1} Кешированное значение: {cachedFraction1.GetFinalValue()}");

            cachedFraction2.SetDenominator(4);
            Console.WriteLine($"Обновили {fraction2} Кешированное значение: {cachedFraction2.GetFinalValue()}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void MeowAll(IEnumerable<IMeowable> meowables)
    {
        foreach (var meowable in meowables)
        {
            meowable.Meow();
        }
    }
}